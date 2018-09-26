using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBorderController : MonoBehaviour {

    public GameObject topBorder;
    public GameObject leftBorder;
    public GameObject rightBorder;
    public GameObject bottomBorder;

    // Use this for initialization
    void Start ()
    {
        Vector2 size = new Vector2(Screen.width, Screen.height);
        Vector3 cameraSize = Camera.main.ScreenToWorldPoint(size);

        Debug.Log(cameraSize);

        leftBorder.transform.position = new Vector3(-cameraSize.x, 0, 0);
        rightBorder.transform.position = new Vector3(cameraSize.x, 0, 0);
        topBorder.transform.position = new Vector3(0, cameraSize.y, 0);
        bottomBorder.transform.position = new Vector3(0, -cameraSize.y - 1, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
