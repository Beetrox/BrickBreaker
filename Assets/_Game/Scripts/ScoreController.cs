using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour {

    TextMeshProUGUI textMesh;
    public int score = 0;

	// Use this for initialization
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

    // Update is called once per frame
    void Update () {
        SetScore(score);
		
	}
}
