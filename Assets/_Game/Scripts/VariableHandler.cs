using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableHandler : MonoBehaviour
{
    public bool endlessMode;
    public int finalScore;

    public int savedScore;
    public int savedLives;
    public int savedLevel;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
