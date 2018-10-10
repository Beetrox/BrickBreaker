using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{

    int moveSpeed = 10;

    private void Start()
    {
        Vector2 size = new Vector2(Screen.width, Screen.height);
        Vector3 cameraSize = Camera.main.ScreenToWorldPoint(size);
        
        float cameraX = cameraSize.x;
        float cameraY = cameraSize.y;
        float cameraZ = cameraSize.z;

        transform.localScale = new Vector3(cameraX/5, cameraY/9, cameraZ);
        Debug.Log(transform.localScale);
        transform.position = new Vector3(0, -cameraY+cameraY/6, 0);
    }

    void Update()
    {
        Vector3 position = Camera.main.WorldToViewportPoint(transform.position);
        position.x = Mathf.Clamp01(position.x);
        position.y = Mathf.Clamp01(position.y);
        transform.position = Camera.main.ViewportToWorldPoint(position);

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary)
        {
            Vector2 touchPosition = Input.GetTouch(0).position;
            double halfScreen = Screen.width / 2.0;

            //Check if click is left or right side
            if (touchPosition.x < halfScreen)
            {
                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            }
            else if (touchPosition.x > halfScreen)
            {
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            }
        }
    }

    public void PowerUpFlash()
    {
        Debug.Log("flashing");
    }
}
