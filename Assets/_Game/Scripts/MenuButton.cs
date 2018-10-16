using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        //Debug.Log("menu");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
