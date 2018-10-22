using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpProperties : MonoBehaviour
{
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

    private void ExecutePowerUp()
    {

    }
}
