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
    public bool endless;

    public int levelNumber = 1;
    
	void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;

        endless = false;

        livesController.RestoreLives();

        Init();
	}

    void Init()
    {
        brickController.SetUpBricks(levelNumber);
        SpawnPaddle();
    }

    void Update()
    {
        GameObject paddle = GameObject.FindGameObjectWithTag("Paddle");
        paddleController = paddle.GetComponent<PaddleController>();
        ball = GameObject.FindGameObjectWithTag("Ball");

        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("MainMenu");

                return;
            }
        }
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
                if (!endless)
                {
                    Debug.Log("YOU WON!");
                    SceneManager.LoadScene("MainMenu");
                    gameOver = true;
                }
                else
                {
                    brickController.SetUpBricks(finalLevel);
                    StartCoroutine(paddleController.SpawnNewBall());
                }
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

    Vector3 GetCameraSize()
    {
        Vector2 size = new Vector2(Screen.width, Screen.height);
        Vector3 cameraSize = Camera.main.ScreenToWorldPoint(size);
        return cameraSize;
    }
}
