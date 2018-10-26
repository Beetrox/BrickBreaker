﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject ballPrefab;
    GameObject ball;

    public bool ballReleased = false;
    public bool extraball = false;
    public bool hasPowerUp = false;
    int moveSpeed = 10;

    private void Start()
    {
        Vector2 size = new Vector2(Screen.width, Screen.height);
        Vector3 cameraSize = Camera.main.ScreenToWorldPoint(size);
        
        float cameraX = cameraSize.x;
        float cameraY = cameraSize.y;
        float cameraZ = cameraSize.z;

        transform.localScale = new Vector3(cameraX/11, cameraY/11, cameraZ);
        transform.position = new Vector3(0, -cameraY+cameraY/6, 0);
        
        StartCoroutine("SpawnNewBall");
    }

    void Update()
    {
        Vector3 position = Camera.main.WorldToViewportPoint(transform.position);
        position.x = Mathf.Clamp01(position.x);
        position.y = Mathf.Clamp01(position.y);
        transform.position = Camera.main.ViewportToWorldPoint(position);

        // paddle for touch input
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary)
        {
            Vector2 touchPosition = Input.GetTouch(0).position;
            double halfScreen = Screen.width / 2.0;

            //Check if click is left or right side
            if (touchPosition.x < halfScreen)
            {
                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            }
            else if (touchPosition.x > halfScreen)
            {
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            }
        }

        // paddle for keyboard input
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }

        if (ball && !ballReleased)
        {
            ball.transform.position = BallSpawnPosition();

            // ball release for touch input
            foreach (Touch touch in Input.touches)
            {

                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                touchPosition.z = 0;

                RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);

                {
                    if (hit.collider != null && hit.collider.tag == "Ball")
                    {
                        pushBall();
                        ballReleased = true;
                    }
                }
            }

            // ball release for keyboard input
            if (Input.GetButtonDown("Jump"))
            {
                pushBall();
                ballReleased = true;
            }
        }
    }

    void pushBall()
    {
        ball.GetComponentInChildren<Rigidbody2D>().AddForce(new Vector2(0, 6f), ForceMode2D.Impulse);
    }

    public IEnumerator SpawnNewBall()
    {
        if (extraball)
        {
            if (!GameObject.FindGameObjectWithTag("ExtraBall"))
            {
                Debug.Log("Extra ball");
                Vector3 ballSpawnLocation = BallSpawnPosition();
                ball = Instantiate(ballPrefab, ballSpawnLocation, transform.rotation);
                ball.tag = "ExtraBall";
                ballReleased = false;
                extraball = false;
            }
        }

        yield return new WaitForSeconds(1);
        if (!GameObject.FindGameObjectWithTag("Ball"))
        {
            Vector3 ballSpawnLocation = BallSpawnPosition();
            ball = Instantiate(ballPrefab, ballSpawnLocation, transform.rotation);
            ballReleased = false;
        }
    }

    Vector3 BallSpawnPosition()
    {
        Vector3 paddlePosition = gameObject.transform.position;
        Vector3 ballSpawnLocation = paddlePosition + new Vector3(0, 1, 0);
        return ballSpawnLocation;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject ball = GameObject.FindGameObjectWithTag("Ball");
        BallController ballController = ball.GetComponent<BallController>();
        
        foreach (ContactPoint2D contactPoint in collision.contacts)
        {
            if(collision.transform.tag == "Ball")
            {
                ballController.touchedPaddle = true;
                Vector2 hitpoint = contactPoint.point;
                float calc = hitpoint.x - transform.position.x;
                contactPoint.collider.GetComponent<Rigidbody2D>().AddForce(new Vector2(70, 0) * calc);
            }
        }
    }
}
