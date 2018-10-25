using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    VariableHandler variableHandler;

    private void Start()
    {
        GameObject variableObject = GameObject.FindGameObjectWithTag("VariableHandler");
        variableHandler = variableObject.GetComponent<VariableHandler>();
    }

    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Debug.Log("QUIT");
                Application.Quit();

                return;
            }
        }
    }

    public void PlayGame()
    {
        variableHandler.endlessMode = false;
        variableHandler.survivalMode = false;
        SceneManager.LoadScene("Level 1");
    }

    public void EndlessMode()
    {
        variableHandler.endlessMode = true;
        variableHandler.survivalMode = false;
        SceneManager.LoadScene("Level 1");
    }

    public void SurvivalMode()
    {
        variableHandler.endlessMode = false;
        variableHandler.survivalMode = true;
        SceneManager.LoadScene("Level 1");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }


    public void ContinueGame()
    {
        SceneManager.LoadScene("Level 1");
    }
}
