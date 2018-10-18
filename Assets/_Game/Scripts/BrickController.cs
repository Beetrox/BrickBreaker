using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject ballPrefab;
    public GameObject brickPrefab;
    public GameObject powerUpBigPaddle;
    public GameObject powerUpBigBall;
    public GameObject powerUpSmallPaddle;
    public ScoreController scoreController;
    GameObject brick;

    public List<GameObject> powerUpPrefabs = new List<GameObject>();

    public void SetUpBricks(int levelNumber)
    {
        //Debug.Log("set up bricks");
        Vector2 size = new Vector2(Screen.width, Screen.height);
        Vector3 cameraSize = Camera.main.ScreenToWorldPoint(size);

        float cameraX = cameraSize.x;
        float cameraY = cameraSize.y;
        float cameraZ = cameraSize.z;

        int gridColumns = 9;
        int gridRows = levelNumber;

        float brickSpacingX = cameraX / 5.6f;
        float brickSpacingY = cameraY / 9;
        float startPositionX = 0 - brickSpacingX * (gridColumns / 2);
        float startPositionY = cameraY - cameraY * 0.3f;

        for (int y = 0; y < gridRows; y++)
        {
            for (int x = 0; x < gridColumns; x++)
            {
                Vector3 spawnPosition = new Vector3(startPositionX + x * brickSpacingX, startPositionY - y * brickSpacingY, 0);
                brick = Instantiate(brickPrefab, spawnPosition, Quaternion.identity) as GameObject;
                brick.name = x + "/" + y;
                brick.transform.parent = gameObject.transform;
            }
        }
    }

    public void BrickDestroyed(Vector3 position)
    {
        scoreController.score++;
        //scoreController.SetScore(newScore);

        int randomPowerUp = Random.Range(1, 3);

        if (randomPowerUp == 1)
        {
            int random = Random.Range(0, 4);
            // why this rotation?
            Instantiate(powerUpPrefabs[random], position, powerUpBigPaddle.transform.rotation);
        }

        gameManager.StartCoroutine("NextLevel");
    }
}
