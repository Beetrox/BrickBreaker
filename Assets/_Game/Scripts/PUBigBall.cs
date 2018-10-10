using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUBigBall : MonoBehaviour
{
    GameObject ball;
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
            //ball = GameObject.FindGameObjectWithTag("Ball");
            //Vector3 baseSize = ball.GetComponent<CircleCollider2D>().bounds.size;
            //float ballDiameter = baseSize.x*1.2f;
            //ball.transform.localScale += new Vector3(ballDiameter, ballDiameter, ballDiameter);
            ////ball.transform.localScale = new Vector3(1, 1, 1);
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
        ball = GameObject.FindGameObjectWithTag("Ball");
        Vector3 baseSize = ball.GetComponent<CircleCollider2D>().bounds.size;
        float ballDiameter = baseSize.x * 1.2f;
        ball.transform.localScale += new Vector3(ballDiameter, ballDiameter, ballDiameter);
        gameObject.transform.localScale = new Vector3(0, 0, 0);

        yield return new WaitForSeconds(powerUpTime);
        ball.transform.localScale += baseSize;
        Destroy(gameObject);
    }
}
