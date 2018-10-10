using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUBigPaddle : MonoBehaviour
{
    GameObject paddle;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("collided");
        if (collision.gameObject.tag == "Paddle")
        {
            //Debug.Log("power up");
            // connect to FastBall()
            paddle = GameObject.FindGameObjectWithTag("Paddle");
            Vector3 baseSize = paddle.GetComponent<BoxCollider2D>().bounds.size;
            float paddleWidth = baseSize.x;
            paddle.transform.localScale += new Vector3(paddleWidth, paddleWidth, paddleWidth);
            //paddle.transform.localScale = new Vector3(size*1.2, ;
            Destroy(gameObject, 0.05f);
        }

        if (collision.gameObject.tag == "Bottom")
        {
            //Debug.Log("bottom");
            Destroy(gameObject);
        }
        //inputController.PowerUpFlash();
    }
}
