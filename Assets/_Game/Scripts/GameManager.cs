using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject ballPrefab;
    public GameObject inputPrefab;
    Vector3 ballSpawnLocation = new Vector3(0, 0, 0);
    Vector3 inputSpawnLocation;
    public BallController ballController;
    public BrickController bricksController;
    int ballForce = -6;

    private GameObject _ball;
    int ballHash;

	// Use this for initialization
	void Start ()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        bricksController.SetUpBricks();
        SpawnInput();
        SpawnNewBall();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //reset input position?
        SpawnNewBall();
        //Debug.Log(string.Format("Ball speed:{0}", _ball.GetComponentInChildren<Rigidbody2D>().velocity));
    }

    void SpawnInput()
    {
        Vector2 size = new Vector2(Screen.width, Screen.height);
        Vector3 cameraSize = Camera.main.ScreenToWorldPoint(size);

        float cameraX = cameraSize.x;
        float cameraY = cameraSize.y;
        float cameraZ = cameraSize.z;

        inputSpawnLocation = new Vector3(0, 0, 0);

        GameObject input = Instantiate(inputPrefab, inputSpawnLocation, transform.rotation);
    }

    void SpawnNewBall()
    {
        if (!GameObject.FindGameObjectWithTag("Ball"))
        {
            //Debug.Log("spawn");
            GameObject ball = Instantiate(ballPrefab, ballSpawnLocation, transform.rotation);
            //ballController.gameManager = this;
            ball.tag = "Ball";
            Rigidbody2D rigidbody = (Rigidbody2D)ball.GetComponentInChildren(typeof(Rigidbody2D));
            rigidbody.AddForce(new Vector2(0, ballForce), ForceMode2D.Impulse);
            _ball = ball;
        }
    }

    public void DestroyObject(GameObject gameObject)
    {
        Destroy(gameObject.transform.parent.gameObject);
    }
}
