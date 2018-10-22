using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUExtraBall : MonoBehaviour
{
    GameObject ball;
    GameObject paddle;
    PaddleController paddleController;

    private void Start()
    {
        paddle = GameObject.FindGameObjectWithTag("Paddle");
        if (paddle)
        {
            paddleController = paddle.GetComponent<PaddleController>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("collided");
        if (collision.gameObject.tag == "Paddle")
        {
            ExecutePowerUp();
        }

        if (collision.gameObject.tag == "Bottom")
        {
            //Debug.Log("bottom");
            Destroy(gameObject);
        }
    }

    private void ExecutePowerUp()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
        if (ball)
        {
            paddleController.extraball = true;
            StartCoroutine(paddleController.SpawnNewBall());
            Destroy(gameObject);
        }
    }
}
