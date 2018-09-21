using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{

    public int moveSpeed = 8;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);

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
}
