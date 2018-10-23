using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject ballPrefab;
    public GameObject paddlePrefab;
    GameObject variableObject;
    GameObject ball;
    public BallController ballController;
    public BrickController brickController;
    public LivesController livesController;
    PaddleController paddleController;

    public int levelNumber;
    int ballForce = -6;
    int finalLevel = 10;
    [HideInInspector]
    public bool gameOver = false;
    public bool endless = true;
    Vector3 ballSpawnLocation = new Vector3(0, 0, 0);
    Vector3 paddleSpawnLocation;
    
	void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;

        variableObject = GameObject.FindGameObjectWithTag("VariableHandler");
        if(variableObject)
        {
            VariableHandler variableHandler = variableObject.GetComponent<VariableHandler>();
            endless = variableHandler.endlessMode;
        }
        else
        {
            endless = true;
        }

        levelNumber = 1;

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
        if (paddle)
        {
            paddleController = paddle.GetComponent<PaddleController>();
        }
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
                    VariableHandler variableHandler = variableObject.GetComponent<VariableHandler>();
                    GameObject scoreObject = GameObject.FindGameObjectWithTag("Score");
                    ScoreController scoreController = scoreObject.GetComponent<ScoreController>();
                    variableHandler.finalScore = scoreController.score;
                    variableHandler.winner = true;
                    SceneManager.LoadScene("GameOver");
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

    public void GameOver()
    {
        Debug.Log("Game over");

        VariableHandler variableHandler = variableObject.GetComponent<VariableHandler>();
        GameObject scoreObject = GameObject.FindGameObjectWithTag("Score");
        ScoreController scoreController = scoreObject.GetComponent<ScoreController>();
        variableHandler.finalScore = scoreController.score;
        variableHandler.winner = false;
        SceneManager.LoadScene("GameOver");
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
