using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public GameManager gameManager;
    public GameObject explosion;
    public GameObject powerUpPrefab;
    public GameObject ball;
    public GameObject bricks;
    public BallController ballController;
    public BrickController brickController;

    BoxCollider2D boxCollider;

    int randomPowerUp;
    
	void Start ()
    {
        boxCollider = gameObject.GetComponentInChildren<BoxCollider2D>();

        ball = GameObject.FindGameObjectWithTag("Ball");
        ballController = ball.GetComponent<BallController>();

        bricks = GameObject.FindGameObjectWithTag("Bricks");
        brickController = bricks.GetComponent<BrickController>();
        //gameManager = 

        Vector2 size = new Vector2(Screen.width, Screen.height);
        Vector3 cameraSize = Camera.main.ScreenToWorldPoint(size);

        float cameraX = cameraSize.x;
        float cameraY = cameraSize.y;
        float cameraZ = cameraSize.z;

        transform.localScale = new Vector3(cameraX / 7f, cameraY / 16, cameraZ);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("collided");
        if (collision.gameObject.tag == "Ball")
        {
            //Debug.Log("hit ball");
            brickController.BrickDestroyed();
            Instantiate(explosion, transform.position, explosion.transform.rotation);
            //StartCoroutine(gameManager.NextLevel());
            Destroy(gameObject, 0.05f);
        }
    }
}
