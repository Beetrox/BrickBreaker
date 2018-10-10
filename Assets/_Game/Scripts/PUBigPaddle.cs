using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUBigPaddle : MonoBehaviour
{
    GameObject paddle;
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
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = new Vector2(0, 0);
        rigidbody2D.gravityScale = 0;
        paddle = GameObject.FindGameObjectWithTag("Paddle");
        Vector3 baseSize = paddle.transform.localScale;
        Debug.Log(baseSize);
        float paddleX = baseSize.x;
        float newWidth = paddleX / 3;
        paddle.transform.localScale += new Vector3(newWidth, 0, 0);
        Debug.Log(paddle.transform.localScale);
        gameObject.transform.localScale = new Vector3(0, 0, 0);

        yield return new WaitForSeconds(powerUpTime);
        paddle.transform.localScale = baseSize;
        Debug.Log(paddle.transform.localScale);
        Destroy(gameObject);
    }
}
