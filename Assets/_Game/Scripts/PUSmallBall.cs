using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSmallBall : PowerUpProperties
{
    GameObject ball;
    int powerUpTime = 5;

    protected override void ExecutePowerUp()
    {
        StartCoroutine("ExecutePowerUpCoroutine");
    }

    IEnumerator ExecutePowerUpCoroutine()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
        if (ball)
        {
            BallController ballController = ball.GetComponent<BallController>();

            if (ball != null && !ballController.hasPowerUp)
            {
                Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
                rigidbody2D.velocity = new Vector2(0, 0);
                rigidbody2D.gravityScale = 0;
                ballController.hasPowerUp = true;
                Vector3 baseSize = ball.transform.localScale;
                float ballDiameter = baseSize.x;
                float newSize = ballDiameter / 2;
                ball.transform.localScale -= new Vector3(newSize, newSize, newSize);
                gameObject.transform.localScale = new Vector3(0, 0, 0);

                yield return new WaitForSeconds(powerUpTime);
                if (ball != null)
                {
                    ball.transform.localScale = baseSize;
                    ballController.hasPowerUp = false;
                }
                EndPowerUp();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
