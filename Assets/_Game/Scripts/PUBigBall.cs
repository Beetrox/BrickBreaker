using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUBigBall : MonoBehaviour
{
    GameObject ball;
    int powerUpTime = 5;
    public BallController ballController;

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
        //if(!ballController.hasPowerUp)
        //{ 
            Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
            rigidbody2D.velocity = new Vector2(0, 0);
            rigidbody2D.gravityScale = 0;
            ball = GameObject.FindGameObjectWithTag("Ball");
            //ballController = ball.GetComponent<BallController>();
            //ballController.hasPowerUp = true;
            Vector3 baseSize = ball.transform.localScale;
            //Debug.Log(baseSize);
            float ballDiameter = baseSize.x;
            float newSize = ballDiameter / 2;
            ball.transform.localScale += new Vector3(newSize, newSize, newSize);
            //Debug.Log(ball.transform.localScale);
            gameObject.transform.localScale = new Vector3(0, 0, 0);

            yield return new WaitForSeconds(powerUpTime);
            ball.transform.localScale = baseSize;
            //ballController.hasPowerUp = false;
            //Debug.Log(ball.transform.localScale);
            Destroy(gameObject);
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}
    }
}
