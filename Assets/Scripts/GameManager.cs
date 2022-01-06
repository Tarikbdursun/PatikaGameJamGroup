using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Helpers;


public class GameManager : MonoSingleton<GameManager>
{
    public bool IsGameStart { get; set; }

    void Update()
    {
        if (Input.GetMouseButton(0) && !IsGameStart)
        {
            IsGameStart = true;
        }
    }
}
