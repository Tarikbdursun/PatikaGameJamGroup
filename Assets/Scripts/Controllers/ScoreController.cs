using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helpers;
using System;

public class ScoreController : MonoSingleton<ScoreController>
{
    public int GoodScore {get; set;}
    public int BadScore {get; set;}
    public int ProgressScore {get; set;}


    private void Start() 
    {
        GameManager.Instance.StartGame += OnStartGame;
    }

    private void OnStartGame()
    {
        GoodScore = 0;
        BadScore = 0;
        ProgressScore = 0;
    }
}
