﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableHandler : MonoBehaviour
{
    public bool endlessMode = false;
    public bool survivalMode = false;
    public bool winner;
    public int finalScore;

    public int savedScore;
    public int savedLives;
    public int savedLevel;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
