using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUExtraBall : PowerUpProperties
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

    protected override void ExecutePowerUp()
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
