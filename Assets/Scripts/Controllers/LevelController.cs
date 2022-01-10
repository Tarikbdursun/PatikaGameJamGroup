using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helpers;
using System;

public class LevelController : MonoSingleton<LevelController>
{
    public GameObject MaleCharacter;
    public event Action NextLevel;

    #region Variables

    public int LevelIndex => currentLevelIndex;
    public GameObject FinishPlane {get; set;} = null;
    private Level[] levels;
    private int currentLevelIndex;

    #endregion

    #region Unity Methods

    private void Awake()
    {
        SetupLevel();
        CloseAllLevels();
        currentLevelIndex = PlayerPrefs.GetInt("Level_Index", 0);
        
        levels[currentLevelIndex].GetComponent<Plane>().GeneratePlane();
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
        levels = GetComponentsInChildren<Level>();
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
        levels[currentLevelIndex].GetComponent<Plane>().GeneratePlane();
    }

    #endregion

}
