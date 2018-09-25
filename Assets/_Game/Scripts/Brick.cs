using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public GameManager gameManager;
    public GameObject explosion;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("collided");
        if (collision.gameObject.tag == "Ball")
        {
            //Debug.Log("hit ball");
            Destroy(gameObject, 0.05f);
            Instantiate(explosion, transform.position, explosion.transform.rotation);
        }
    }
}
