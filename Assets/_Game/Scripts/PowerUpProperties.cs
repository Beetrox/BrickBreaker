using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpProperties : MonoBehaviour
{
    public GameObject explosion;

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("collided");
        if (collision.gameObject.tag == "Paddle")
        {
            ExecutePowerUp();
            Explosion();
        }

        if (collision.gameObject.tag == "Bottom")
        {
            //Debug.Log("bottom");
            Destroy(gameObject);
        }
    }

    private void Explosion()
    {
        Instantiate(explosion, transform.position, explosion.transform.rotation);
    }

    protected virtual void ExecutePowerUp()
    {
        // action when power up hits the paddle
    }
}
