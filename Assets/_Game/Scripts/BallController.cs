using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameManager gameManager;
    PaddleController paddleController;
    LivesController livesController;
    Rigidbody2D rigidbody;

    public bool hasPowerUp = false;
    public bool touchedPaddle = true;
    //Vector2 constantVelocity = new Vector2(1f, 1f);
    float constantSpeed = 6f;

    void Start()
    {
        GameObject managerObject = GameObject.FindGameObjectWithTag("GameManager");
        gameManager = managerObject.GetComponent<GameManager>();

        Vector2 size = new Vector2(Screen.width, Screen.height);
        Vector3 cameraSize = Camera.main.ScreenToWorldPoint(size);

        float cameraX = cameraSize.x;
        float cameraY = cameraSize.y;
        float cameraZ = cameraSize.z;

        float ballDiameter = cameraX / 13;

        rigidbody = gameObject.GetComponentInChildren<Rigidbody2D>() as Rigidbody2D;
        //Vector3 ballSize = new Vector3(ballDiameter, ballDiameter, ballDiameter);
        transform.localScale = new Vector3(ballDiameter, ballDiameter, ballDiameter);
        //Debug.Log(transform.localScale);
        Vector3 growSize = transform.localScale;
        LeanTween.scale(gameObject, growSize, 0.15f).setEaseInQuad();

        GameObject paddle = GameObject.FindGameObjectWithTag("Paddle");
        paddleController = paddle.GetComponent<PaddleController>();

        if (GameObject.FindGameObjectWithTag("Lives"))
        {
            GameObject lives = GameObject.FindGameObjectWithTag("Lives");
            livesController = lives.GetComponent<LivesController>();
        }

        //if (gameObject.tag == "ExtraBall")
        //{
        //    gameObject.GetComponentInChildren<Rigidbody2D>().AddForce(new Vector2(0, 6f), ForceMode2D.Impulse);
        //}
    }

    void Update()
    {
        ConstantSpeed();
    }

    void ConstantSpeed()
    {
        rigidbody.velocity = constantSpeed * (rigidbody.velocity.normalized);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("collided");
        if (collision.gameObject.tag == "Bottom")
        {
            // toggle endless mode
            if (!gameManager.endless)
            {
                livesController.RemoveLife();
            }

            //if (gameObject.tag == "Ball")
            //{
            //    GameObject newBall = GameObject.FindGameObjectWithTag("ExtraBall");
            //    newBall.tag = "Ball";
            //}

            // if extra ball no point taken
            // if ball set extra ball to ball
            paddleController.StartCoroutine("SpawnNewBall");
            Destroy(transform.parent.gameObject);
        }
    }
}
