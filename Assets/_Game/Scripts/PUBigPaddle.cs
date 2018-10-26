using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUBigPaddle : PowerUpProperties
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
            float paddleX = baseSize.x;
            paddle.transform.localScale += new Vector3(paddleX, 0, 0);
            gameObject.transform.localScale = new Vector3(0, 0, 0);

            yield return new WaitForSeconds(powerUpTime);
            paddle.transform.localScale = baseSize;
            paddleController.hasPowerUp = false;
            EndPowerUp();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
