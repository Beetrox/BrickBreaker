using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject explosion;
    public GameObject powerUpPrefab;
    public GameObject bricks;
    public BrickController brickController;

    BoxCollider2D boxCollider;

    int randomPowerUp;
    
	void Start ()
    {
        boxCollider = gameObject.GetComponentInChildren<BoxCollider2D>();

        bricks = GameObject.FindGameObjectWithTag("Bricks");
        brickController = bricks.GetComponent<BrickController>();

        Vector2 size = new Vector2(Screen.width, Screen.height);
        Vector3 cameraSize = Camera.main.ScreenToWorldPoint(size);

        float cameraX = cameraSize.x;
        float cameraY = cameraSize.y;
        float cameraZ = cameraSize.z;

        transform.localScale = new Vector3(cameraX / 26f, cameraY / 16, cameraZ);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject ball = GameObject.FindGameObjectWithTag("Ball");
        BallController ballController = ball.GetComponent<BallController>();

        //Debug.Log("collided");
        if (collision.gameObject.tag == "Ball")
        {
            //Debug.Log("hit ball");
            Vector3 position = transform.position;
            brickController.BrickDestroyed(position);
            Instantiate(explosion, transform.position, explosion.transform.rotation);
            ballController.touchedPaddle = false;
            //StartCoroutine(gameManager.NextLevel());

            Destroy(gameObject, 0.05f);
        }
    }
}
