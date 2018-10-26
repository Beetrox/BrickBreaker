using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBorderController : MonoBehaviour
{
    public GameObject topBorder;
    public GameObject leftBorder;
    public GameObject rightBorder;
    public GameObject bottomBorder;
    
    void Start ()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;

        Vector2 size = new Vector2(Screen.width, Screen.height);
        Vector3 cameraSize = Camera.main.ScreenToWorldPoint(size);

        //placing camera borders relative to camera size
        leftBorder.transform.position = new Vector3(-cameraSize.x, 0, 0);
        rightBorder.transform.position = new Vector3(cameraSize.x, 0, 0);
        topBorder.transform.position = new Vector3(0, cameraSize.y, 0);
        bottomBorder.transform.position = new Vector3(0, -cameraSize.y - 1, 0);
	}
}
