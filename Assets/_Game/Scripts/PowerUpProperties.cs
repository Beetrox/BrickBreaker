using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpProperties : MonoBehaviour
{
    public GameObject explosion;
    GameManager gameManager;

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject managerObject = GameObject.FindGameObjectWithTag("GameManager");
        gameManager = managerObject.GetComponent<GameManager>();
        
        if (collision.gameObject.tag == "Paddle")
        {
            ExecutePowerUp();
            gameManager.powerUpActive = true;
            Explosion();
        }

        if (collision.gameObject.tag == "Bottom")
        {
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

    protected void EndPowerUp()
    {
        Destroy(gameObject);
        gameManager.powerUpActive = false;
    }
}
