using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helpers;
using System;

public class LevelController : MonoSingleton<LevelController>
{
    public event Action NextLevel;

    #region Variables

    public int LevelIndex => currentLevelIndex;
    private BaseLevel[] levels;
    private int currentLevelIndex;

    #endregion

    #region Unity Methods

    private void Awake()
    {
        SetupLevel();
        CloseAllLevels();
        currentLevelIndex = PlayerPrefs.GetInt("Level_Index", 0);
    }

    private void Start()
    {
        levels[currentLevelIndex].gameObject.SetActive(true);
        NextLevel += OnNextLevel;
    }

    #endregion

    #region Methods

    public void GetNextLevel()
    {
        NextLevel?.Invoke();
    }

    private void SetupLevel()
    {
        levels = GetComponentsInChildren<BaseLevel>();
    }

    private void CloseAllLevels()
    {
        foreach (var level in levels)
        {
            level.gameObject.SetActive(false);
        }
    }

    #endregion

    #region Callbacks

    private void OnNextLevel()
    {
        levels[currentLevelIndex].gameObject.SetActive(false);

        currentLevelIndex++;
        
        if (currentLevelIndex >= levels.Length)
        {
            Debug.Log("all levels completed");
            return;
        }
        PlayerPrefs.SetInt("Level_Index", currentLevelIndex);

        levels[currentLevelIndex].gameObject.SetActive(true);
    }

    #endregion

}
