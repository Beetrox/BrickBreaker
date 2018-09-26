using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public GameManager gameManager;
    public GameObject explosion;
    public GameObject powerUpPrefab;

    int randomPowerUp;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        randomPowerUp = Random.Range(1, 4);

        //Debug.Log("collided");
        if (collision.gameObject.tag == "Ball")
        {
            //Debug.Log("hit ball");
            if(randomPowerUp == 1)
            {
                Debug.Log("power up spawned");
                Instantiate(powerUpPrefab, transform.position, powerUpPrefab.transform.rotation);
            }
            Instantiate(explosion, transform.position, explosion.transform.rotation);
            Destroy(gameObject, 0.05f);
        }
    }
}
