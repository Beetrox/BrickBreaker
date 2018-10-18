using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    TextMeshProUGUI textMesh;
    public int score = 0;
    
	void Start ()
    {
        {
            textMesh = gameObject.GetComponent<TextMeshProUGUI>();

            SetScore(score);

            if (textMesh == null)
            {
                Debug.LogError("TextMesh component not found");
            }
        }
    }

    public void SetScore(int score)
    {
        textMesh.SetText("Score: " + score.ToString());
    }
    
    void Update ()
    {
        SetScore(score);
	}
}
