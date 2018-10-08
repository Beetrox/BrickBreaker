using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    PaddleController paddleController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("collided");
        if (collision.gameObject.tag == "Paddle")
        {
            //Debug.Log("power up");
            // connect to FastBall()
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
