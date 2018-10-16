using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject ballPrefab;
    GameObject ball;

    bool ballReleased = false;
    int moveSpeed = 10;
    public bool hasPowerUp = false;

    private void Start()
    {
        Vector2 size = new Vector2(Screen.width, Screen.height);
        Vector3 cameraSize = Camera.main.ScreenToWorldPoint(size);

        //gameManager = GameObject.FindGameObjectWithTag("GameManager");
        //GameManager script = gameManager.GetComponent("GameManager);
        
        float cameraX = cameraSize.x;
        float cameraY = cameraSize.y;
        float cameraZ = cameraSize.z;

        transform.localScale = new Vector3(cameraX/3, cameraY/13, cameraZ);
        //Debug.Log(transform.localScale);
        transform.position = new Vector3(0, -cameraY+cameraY/6, 0);

        //spawn ball from here
        //SpawnNewBall();
        StartCoroutine("SpawnNewBall");
    }

    void Update()
    {
        //Vector2 paddleSize = gameObject.GetComponentInChildren<BoxCollider2D>().bounds.size;
        //float paddleX = paddleSize.x;

        //Vector3 paddleSize = gameObject.transform.localScale;
        //float paddleX = paddleSize.x;
        //Debug.Log(paddleX);

        Vector3 position = Camera.main.WorldToViewportPoint(transform.position);
        position.x = Mathf.Clamp01(position.x);
        position.y = Mathf.Clamp01(position.y);
        transform.position = Camera.main.ViewportToWorldPoint(position);

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

        if (ball && !ballReleased)
        {
            //Rigidbody2D ballRigidbody = ball.GetComponent<Rigidbody2D>();
            ball.transform.position = BallSpawnPosition();

            //for touch input
            foreach (Touch touch in Input.touches)
            {

                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                touchPosition.z = 0;

                RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);

                {
                    if (hit.collider != null && hit.collider.tag == "Ball")
                    {
                        //Debug.Log("release ball");
                        ball.GetComponentInChildren<Rigidbody2D>().AddForce(new Vector2(0, 6f), ForceMode2D.Impulse);
                        ballReleased = true;
                    }
                }
            }

            //for keyboard input
            //if (Input.GetButtonDown("Jump"))
            //{
            //    //Debug.Log("release ball");
            //    ball.GetComponentInChildren<Rigidbody2D>().AddForce(new Vector2(0, 6f), ForceMode2D.Impulse);
            //    ballReleased = true;
            //}
        }
    }

    public IEnumerator SpawnNewBall()
    {
        yield return new WaitForSeconds(1);
        if (!GameObject.FindGameObjectWithTag("Ball"))
        {
            Vector3 ballSpawnLocation = BallSpawnPosition();
            //Debug.Log("spawn");
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
        //Debug.Log("collided");
        foreach(ContactPoint2D contactPoint in collision.contacts)
        {
            if(collision.transform.tag == "Ball")
            {
                //Debug.Log("collided ball");
                Vector2 hitpoint = contactPoint.point;
                float calc = hitpoint.x - transform.position.x;
                contactPoint.collider.GetComponent<Rigidbody2D>().AddForce(new Vector2(70, 0) * calc);
            }
        }
    }
    
    public void PowerUpFlash()
    {
        Debug.Log("flashing");
    }
}
