using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public GameManager gameManager;
    public GameObject explosion;
    public GameObject powerUpPrefab;
    public GameObject ball;
    public BallController ballController;

    int randomPowerUp;

	// Use this for initialization
	void Start () {

        ball = GameObject.FindGameObjectWithTag("Ball");
        ballController = ball.GetComponent<BallController>();

        Vector2 size = new Vector2(Screen.width, Screen.height);
        Vector3 cameraSize = Camera.main.ScreenToWorldPoint(size);

        float cameraX = cameraSize.x;
        float cameraY = cameraSize.y;
        float cameraZ = cameraSize.z;

        transform.localScale = new Vector3(cameraX / 7, cameraY / 13, cameraZ);

        //Vector2 size = new Vector2(Screen.width, Screen.height);
        //int screenWidth = Screen.width;
        //int screenHeight = Screen.height;
        //Vector3 cameraSize = Camera.main.ScreenToWorldPoint(size);

        //transform.localScale = new Vector2((cameraSize * 1), 1);

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

                //move to PowerUpController
                ballController.FastBall();
                Instantiate(powerUpPrefab, transform.position, powerUpPrefab.transform.rotation);
            }
            Instantiate(explosion, transform.position, explosion.transform.rotation);
            Destroy(gameObject, 0.05f);
        }
    }
}
