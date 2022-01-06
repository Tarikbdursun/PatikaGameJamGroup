using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Helpers;

public class UIController : MonoSingleton<UIController>
{
    #region Variables
    [SerializeField]
    private GameObject startPanel;
    [SerializeField]
    private GameObject inGamePanel;
    [SerializeField]
    private GameObject finishPanel;
    [SerializeField]
    private Text levelText;

    #endregion

    void Start()
    {
        GameManager.Instance.FinishGame += OnFinishGame;
        LevelController.Instance.NextLevel += OnNextLevel;
        GameManager.Instance.StartGame += OnStartGame;

        OnNextLevel();
    }
    
    private void Update()
    {
        levelText.text = (LevelController.Instance.LevelIndex+1).ToString();
    }

    private void CloseAllPanels()
    {
        startPanel.SetActive(false);
        inGamePanel.SetActive(false);
        finishPanel.SetActive(false);
    }

    private void OnFinishGame()
    {
        CloseAllPanels();
        finishPanel.SetActive(true);
    }

    private void OnStartGame()
    {
        CloseAllPanels();
        inGamePanel.SetActive(true);
    }

    private void OnNextLevel()
    {
        CloseAllPanels();
        startPanel.SetActive(true);
    }


}
