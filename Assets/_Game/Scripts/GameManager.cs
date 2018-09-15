using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject ballPrefab;
    Vector3 ballSpawnLocation = new Vector3(0, 0, 0);
    public BallController ballController;
    public BrickController bricksController;

	// Use this for initialization
	void Start ()
    {
        bricksController.SetUpBricks();
        SpawnNewBall();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void SpawnNewBall()
    {
        if (!GameObject.FindGameObjectWithTag("Ball"))
        {
            //Debug.Log("spawn");
            GameObject ball = Instantiate(ballPrefab, ballSpawnLocation, transform.rotation);
            //ballController.gameManager = this;
            ball.tag = "Ball";
        }
    }

    public void DestroyObject(GameObject gameObject)
    {
        Destroy(gameObject.transform.parent.gameObject);
    }
}
