using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUBigPaddle : MonoBehaviour
{
    GameObject paddle;
    int powerUpTime = 5;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("collided");
        if (collision.gameObject.tag == "Paddle")
        {
            StartCoroutine("ExecutePowerUp");
            //Debug.Log("power up");
            // connect to FastBall()
            //paddle = GameObject.FindGameObjectWithTag("Paddle");
            //Vector3 baseSize = paddle.GetComponent<BoxCollider2D>().bounds.size;
            //float paddleWidth = baseSize.x;
            //paddle.transform.localScale += new Vector3(paddleWidth, paddleWidth, paddleWidth);
            //paddle.transform.localScale = new Vector3(size*1.2, ;
            //Destroy(gameObject, 0.05f);
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
        Vector3 baseSize = paddle.GetComponent<BoxCollider2D>().bounds.size;
        float paddleWidth = baseSize.x;
        paddle.transform.localScale += new Vector3(paddleWidth, paddleWidth, paddleWidth);
        gameObject.transform.localScale = new Vector3(0, 0, 0);

        yield return new WaitForSeconds(powerUpTime);
        paddle.transform.localScale = baseSize;
        Destroy(gameObject);
    }
}
