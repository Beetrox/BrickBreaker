using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LivesController : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject lifePrefab;
    Vector3 lifeSpawn;
    //Vector3 lifeSpawn;
    int lives = 3;
    float lifeDistance = 0.7f;

	// Use this for initialization
	void Start ()
    {
        gameManager.GetComponent<GameManager>();

        for (int i = 1; i <= lives; i++)
        {
            lifeSpawn = new Vector3(-6.3f, 4.7f, 0);
            //lifeSpawn = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0));
            GameObject newLife = Instantiate(lifePrefab, lifeSpawn, transform.rotation);
            newLife.transform.SetParent(transform);
            Vector3 position = newLife.transform.position;
            position.x += (i * lifeDistance);
            newLife.transform.position = position;
        }
    }

    public bool RemoveLife()
    {
        if (!gameManager.gameOver)
        {
            lives--;
            transform.GetChild(lives).gameObject.SetActive(false);
        }

        if (lives == 0)
        {
            gameManager.gameOver = true;
            Debug.Log("Game over");
            SceneManager.LoadScene("MainMenu");
            return false;
        }
        return true;

    }

    public void RestoreLives()
    {

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
    }

        // Update is called once per frame
        void Update () {
		
	}
}
