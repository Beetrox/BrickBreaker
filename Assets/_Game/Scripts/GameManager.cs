using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject ballPrefab;
    public GameObject paddlePrefab;
    Vector3 ballSpawnLocation = new Vector3(0, 0, 0);
    Vector3 paddleSpawnLocation;
    public BallController ballController;
    public BrickController brickController;
    public LivesController livesController;
    PaddleController paddleController;
    int ballForce = -6;
    int finalLevel = 10;
    GameObject ball;
    public bool gameOver = false;

    public int levelNumber = 1;
    
	void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;

        livesController.RestoreLives();

        Init();
	}

    void Init()
    {
        brickController.SetUpBricks(levelNumber);
        SpawnPaddle();
        //StartCoroutine("SpawnNewBall");
        //SpawnNewBall();
    }
	
	void Update()
    {
        //reset input position?
        //SpawnNewBall();
        //Debug.Log(string.Format("Ball speed:{0}", _ball.GetComponentInChildren<Rigidbody2D>().velocity));

        //if (gameOver)
        //{
        //    SceneManager.LoadScene("MainMenu");
        //}

        GameObject paddle = GameObject.FindGameObjectWithTag("Paddle");
        paddleController = paddle.GetComponent<PaddleController>();
        ball = GameObject.FindGameObjectWithTag("Ball");
    }

    public IEnumerator NextLevel()
    {
        // Do I need this?
        yield return new WaitForSeconds(0.05f);
        if (!GameObject.FindGameObjectWithTag("Brick"))
        {
            Destroy(ball);
            yield return new WaitForSeconds(1);
            levelNumber++;
            //Debug.Log(levelNumber);
            if(levelNumber <= finalLevel)
            {
                //Debug.Log("set up next level");
                brickController.SetUpBricks(levelNumber);
                StartCoroutine(paddleController.SpawnNewBall());
            }
            else
            {
                Debug.Log("YOU WON!");
                gameOver = true;
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

        //paddleController = paddle.GetComponent<PaddleController>();
        //paddleController.SpawnNewBall();
    }

    Vector3 GetCameraSize()
    {
        Vector2 size = new Vector2(Screen.width, Screen.height);
        Vector3 cameraSize = Camera.main.ScreenToWorldPoint(size);
        return cameraSize;
    }

    //void SpawnNewBall()
    //{
    //    if (!GameObject.FindGameObjectWithTag("Ball"))
    //    {
    //        //Debug.Log("spawn");
    //        GameObject ball = Instantiate(ballPrefab, ballSpawnLocation, transform.rotation);
    //        //ballController.gameManager = this;
    //        //ball.tag = "Ball";
    //        Rigidbody2D rigidbody = (Rigidbody2D)ball.GetComponentInChildren(typeof(Rigidbody2D));
    //        rigidbody.AddForce(new Vector2(0, ballForce), ForceMode2D.Impulse);
    //        //_ball = ball;
    //        //yield return null;
    //    }
    //}

    //public void DestroyObject(GameObject gameObject)
    //{
    //    Destroy(gameObject.transform.parent.gameObject);
    //}
}
