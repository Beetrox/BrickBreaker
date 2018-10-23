using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public void BackToMenu()
    {
        GameObject variableObject = GameObject.FindGameObjectWithTag("VariableHandler");
        VariableHandler variableHandler = variableObject.GetComponent<VariableHandler>();

        GameObject scoreObject = GameObject.FindGameObjectWithTag("Score");
        ScoreController scoreController = scoreObject.GetComponent<ScoreController>();

        GameObject managerObject = GameObject.FindGameObjectWithTag("GameManager");
        GameManager gameManager = managerObject.GetComponent<GameManager>();

        if (GameObject.FindGameObjectWithTag("Lives"))
        {
            GameObject livesObject = GameObject.FindGameObjectWithTag("Lives");
            LivesController livesController = livesObject.GetComponent<LivesController>();
        }

        variableHandler.endlessMode = gameManager.endless;
        //variableHandler.savedScore = scoreController.score;
        //variableHandler.savedLives = livesController.lives;
        //variableHandler.savedLevel = gameManager.levelNumber;

        SceneManager.LoadScene("MainMenu");
    }
}
