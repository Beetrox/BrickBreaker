using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverText : MonoBehaviour
{
    TextMeshProUGUI tmText;
    bool winner;
    
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
}
