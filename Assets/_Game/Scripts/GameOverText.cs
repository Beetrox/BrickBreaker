using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverText : MonoBehaviour
{
    TextMeshProUGUI tmText;
    bool winner;

	// Use this for initialization
	void Start ()
    {
        GameObject variableObject = GameObject.FindGameObjectWithTag("VariableHandler");
        VariableHandler variableHandler = variableObject.GetComponent<VariableHandler>();

        winner = variableHandler.winner;

        tmText = GetComponent<TextMeshProUGUI>();

        if (winner)
        {
            tmText.SetText("YOU WON!");
        }
        if (!winner)
        {
            tmText.SetText("GAME OVER!");
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
