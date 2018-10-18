using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUExtraLife : MonoBehaviour
{
    LivesController livesController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("collided");
        if (collision.gameObject.tag == "Paddle")
        {
            ExecutePowerUp();
        }

        if (collision.gameObject.tag == "Bottom")
        {
            //Debug.Log("bottom");
            Destroy(gameObject);
        }
    }

    void ExecutePowerUp()
    {
        GameObject lives = GameObject.FindGameObjectWithTag("Lives");
        livesController = lives.GetComponent<LivesController>();

        livesController.AddLife();
        Destroy(gameObject);
    }
}
