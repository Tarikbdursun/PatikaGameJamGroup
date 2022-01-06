using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helpers;

public class LevelController : MonoSingleton<LevelController>
{
    #region Variables
    private BaseLevel[] levels;
    private int currentLevelIndex;

    #endregion

    #region Unity Methods

    private void Awake()
    {
        SetupLevel();
        CloseAllLevels();
    }

    private void Start()
    {
        currentLevelIndex = PlayerPrefs.GetInt("Level_Index", 0);
        levels[currentLevelIndex].gameObject.SetActive(true);
    }

    #endregion

    #region Methods

    public void GetNextLevel()
    {
        levels[currentLevelIndex].gameObject.SetActive(false);

        Player.Instance.transform.position = Vector3.zero;

        GameManager.Instance.IsGameStart = false;

        currentLevelIndex++;
        if (currentLevelIndex >= levels.Length)
        {
            Debug.Log("all levels completed");
            return;
        }
        PlayerPrefs.SetInt("Level_Index", currentLevelIndex);

        levels[currentLevelIndex].gameObject.SetActive(true);
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

}
