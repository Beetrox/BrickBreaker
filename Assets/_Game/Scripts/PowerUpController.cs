using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    PaddleController paddleController;
    public List<GameObject> powerUpPrefabs = new List<GameObject>();

    private void Start()
    {
        Vector2 size = new Vector2(Screen.width, Screen.height);
        Vector3 cameraSize = Camera.main.ScreenToWorldPoint(size);

        float cameraX = cameraSize.x;
        float cameraY = cameraSize.y;
        float cameraZ = cameraSize.z;

        float powerUpSize = cameraX / 20;
        
        transform.localScale = new Vector3(powerUpSize, powerUpSize, powerUpSize);
    }

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
