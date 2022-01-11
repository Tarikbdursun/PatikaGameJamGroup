using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Helpers;
using TMPro;

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
    private TextMeshProUGUI levelText;
    [SerializeField]
    private Image Bride;
    [SerializeField]
    private Image BadGirl;

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
        levelText.text ="Level "+ (LevelController.Instance.LevelIndex+1).ToString();
    }

    private void CloseAllPanels()
    {
        startPanel.SetActive(false);
        inGamePanel.SetActive(false);
        finishPanel.SetActive(false);
    }

    private void OnFinishGame()
    {
        finishPanel.SetActive(true);

        if(IsProgressBarScoreGood())
        {
            Bride.gameObject.SetActive(true);
        }
        else
        {
            BadGirl.gameObject.SetActive(true);
        }

        finishPanel.transform.GetChild(1).transform.localScale = Vector3.one*.01f;
        finishPanel.transform.GetChild(1).LeanScale(Vector3.one,.8f);
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

    private bool IsProgressBarScoreGood()
    {
        if(ScoreController.Instance.ProgressScore > 0)
        {
            return true;
        }

        return false;
    }


}
