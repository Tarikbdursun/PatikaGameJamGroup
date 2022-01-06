using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Helpers;


public class GameManager : MonoSingleton<GameManager>
{
    public event Action StartGame;
    public event Action FinishGame;
    public bool IsGameStart => isGameStart;
    private bool isGameStart = false;

    private void Start() 
    {
        LevelController.Instance.NextLevel += OnNextLevel;    
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && !IsGameStart)
        {
            isGameStart = true;
            StartGame?.Invoke();
        }
    }

    public void GetFinishGame()
    {
        FinishGame?.Invoke();
    }

    private void OnNextLevel()
    {
        isGameStart = false;
    }
}
