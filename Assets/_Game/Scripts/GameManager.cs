using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject ballPrefab;
    public GameObject paddlePrefab;
    Vector3 ballSpawnLocation = new Vector3(0, 0, 0);
    Vector3 paddleSpawnLocation;
    public BallController ballController;
    public BrickController brickController;
    int ballForce = -6;

    public int levelNumber = 1;
    
	void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;

        Init();
	}

    void Init()
    {
        brickController.SetUpBricks(levelNumber);
        SpawnPaddle();
        SpawnNewBall();
    }
	
	void Update()
    {
        //reset input position?
        SpawnNewBall();
        //Debug.Log(string.Format("Ball speed:{0}", _ball.GetComponentInChildren<Rigidbody2D>().velocity));

        //if (!GameObject.FindGameObjectWithTag("Brick"))
        //{
        //    StartCoroutine("NextLevel");
        //}
    }

    public IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(1);
        if (!GameObject.FindGameObjectWithTag("Brick"))
        {
            levelNumber++;
            //Debug.Log(levelNumber);
            if(levelNumber <= 10)
            {
                Debug.Log("set up next level");
                brickController.SetUpBricks(levelNumber);
            }
            else
            {
                Debug.Log("YOU WON!");
            }
        }
    }

    void SpawnPaddle()
    {
        Vector2 size = new Vector2(Screen.width, Screen.height);
        Vector3 cameraSize = Camera.main.ScreenToWorldPoint(size);

        float cameraX = cameraSize.x;
        float cameraY = cameraSize.y;
        float cameraZ = cameraSize.z;

        paddleSpawnLocation = new Vector3(0, 0, 0);

        GameObject paddle = Instantiate(paddlePrefab, paddleSpawnLocation, transform.rotation);
    }

    void SpawnNewBall()
    {
        if(!GameObject.FindGameObjectWithTag("Ball"))
        {
            //Debug.Log("spawn");
            GameObject ball = Instantiate(ballPrefab, ballSpawnLocation, transform.rotation);
            //ballController.gameManager = this;
            //ball.tag = "Ball";
            Rigidbody2D rigidbody = (Rigidbody2D)ball.GetComponentInChildren(typeof(Rigidbody2D));
            rigidbody.AddForce(new Vector2(0, ballForce), ForceMode2D.Impulse);
            //_ball = ball;
        }
    }

    public void DestroyObject(GameObject gameObject)
    {
        Destroy(gameObject.transform.parent.gameObject);
    }
}
