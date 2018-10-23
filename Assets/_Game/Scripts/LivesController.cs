using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LivesController : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject lifePrefab;

    Vector3 lifeSpawn;
    public int lives = 5;
    int maxLives = 5;
    float lifeDistance = 0.7f;
    
	void Start ()
    {
        GameObject managerObject = GameObject.FindGameObjectWithTag("GameManager");
        gameManager = managerObject.GetComponent<GameManager>();
    }

    public void SetUpLives()
    {
        if (!gameManager.endless)
        {
            for (int i = 1; i <= lives; i++)
            {
                //GameObject lives = GameObject.FindGameObjectWithTag("Lives");

                //float livesY = lives.transform.position.y;

                lifeSpawn = new Vector3(-6.65f, 4.55f, 0);
                //lifeSpawn = transform.position + new Vector3(0, 0, 0);
                //lifeSpawn = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0));
                GameObject newLife = Instantiate(lifePrefab, lifeSpawn, transform.rotation);
                newLife.transform.SetParent(transform);
                Vector3 position = newLife.transform.position;
                position.x += (i * lifeDistance);
                newLife.transform.position = position;
            }
        }
    }

    public void RemoveLife()
    {
        if (!gameManager.gameOver)
        {
            lives--;
            transform.GetChild(lives).gameObject.SetActive(false);
        }

        if (lives == 0)
        {
            gameManager.gameOver = true;
            gameManager.GameOver();
        }
    }

    public void AddLife()
    {
        if (!gameManager.gameOver && lives < maxLives)
        {
            lives++;
            //Debug.Log(lives);
            transform.GetChild(lives-1).gameObject.SetActive(true);
        }
    }
    
    public void RestoreLives()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
    }
}
