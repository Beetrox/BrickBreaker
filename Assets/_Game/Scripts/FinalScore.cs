using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScore : MonoBehaviour
{
    TextMeshProUGUI tmScore;
    int finalScore;
    
	void Start ()
    {
        tmScore = GetComponent<TextMeshProUGUI>();

        GameObject variableObject = GameObject.FindGameObjectWithTag("VariableHandler");
        VariableHandler variableHandler = variableObject.GetComponent<VariableHandler>();

        finalScore = variableHandler.finalScore;

        tmScore.SetText(finalScore.ToString());
    }
}
