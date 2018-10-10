using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUBigBall : MonoBehaviour
{
    GameObject ball;

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
            //Debug.Log("power up");
            // connect to FastBall()
            ball = GameObject.FindGameObjectWithTag("Ball");
            Vector3 baseSize = ball.GetComponent<CircleCollider2D>().bounds.size;
            float ballDiameter = baseSize.x*1.2f;
            ball.transform.localScale += new Vector3(ballDiameter, ballDiameter, ballDiameter);
            //ball.transform.localScale = new Vector3(1, 1, 1);
            Destroy(gameObject, 0.05f);
        }

        if (collision.gameObject.tag == "Bottom")
        {
            //Debug.Log("bottom");
            Destroy(gameObject);
        }
        //inputController.PowerUpFlash();
    }

    //IEnumerator ExecuteAndWait()
    //{
    //    yield return new WaitForSeconds(5);
    //    Destroy
    //}
}
