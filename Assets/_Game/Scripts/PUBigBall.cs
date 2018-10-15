using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUBigBall : MonoBehaviour
{
    GameObject ball;
    int powerUpTime = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("collided");
        if (collision.gameObject.tag == "Paddle")
        {
            StartCoroutine("ExecutePowerUp");
        }

        if (collision.gameObject.tag == "Bottom")
        {
            //Debug.Log("bottom");
            Destroy(gameObject);
        }
        //inputController.PowerUpFlash();
    }

    IEnumerator ExecutePowerUp()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
        BallController ballController = ball.GetComponent<BallController>();

        if (ball != null && !ballController.hasPowerUp)
        {
            Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
            rigidbody2D.velocity = new Vector2(0, 0);
            rigidbody2D.gravityScale = 0;
            ballController.hasPowerUp = true;
            Vector3 baseSize = ball.transform.localScale;
            //Debug.Log(baseSize);
            float ballDiameter = baseSize.x;
            float newSize = ballDiameter / 2;
            ball.transform.localScale += new Vector3(newSize, newSize, newSize);
            //Debug.Log(ball.transform.localScale);
            gameObject.transform.localScale = new Vector3(0, 0, 0);

            yield return new WaitForSeconds(powerUpTime);
            if (ball != null)
            {
                ball.transform.localScale = baseSize;
                ballController.hasPowerUp = false;
                //Debug.Log(ball.transform.localScale);
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
