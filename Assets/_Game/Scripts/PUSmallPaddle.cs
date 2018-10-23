using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSmallPaddle : PowerUpProperties
{
    GameObject paddle;
    int powerUpTime = 5;

    protected override void ExecutePowerUp()
    {
        StartCoroutine("ExecutePowerUpCoroutine");
    }

    IEnumerator ExecutePowerUpCoroutine()
    {
        paddle = GameObject.FindGameObjectWithTag("Paddle");
        PaddleController paddleController = paddle.GetComponent<PaddleController>();

        if (!paddleController.hasPowerUp)
        {
            Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
            rigidbody2D.velocity = new Vector2(0, 0);
            rigidbody2D.gravityScale = 0;
            paddleController.hasPowerUp = true;
            Vector3 baseSize = paddle.transform.localScale;
            //Debug.Log(baseSize);
            float paddleX = baseSize.x;
            //Debug.Log(paddleX);
            float newWidth = paddleX / 2;
            //Debug.Log(newWidth);
            paddle.transform.localScale -= new Vector3(newWidth, 0, 0);
            //Debug.Log(paddle.transform.localScale);
            gameObject.transform.localScale = new Vector3(0, 0, 0);

            yield return new WaitForSeconds(powerUpTime);
            //Debug.Log("back to normal");
            paddle.transform.localScale = baseSize;
            paddleController.hasPowerUp = false;
            //Debug.Log(paddle.transform.localScale);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
