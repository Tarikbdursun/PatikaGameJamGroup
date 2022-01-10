using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPlane : MonoBehaviour
{

    

    private void OnTriggerEnter(Collider other)
    {
        FinalMovement();
        GameManager.Instance.GetPlayerOnFinish();
    }

    private void FinalMovement()
    {
        LeanTween.moveLocalY(Player.Instance.gameObject, GetFinalScore(), 2);
        LeanTween.moveLocalY(LevelController.Instance.MaleCharacter, GetFinalScore(), 2);
        Player.Instance.OnFinishPlane = true;
        Player.Instance.ResetWalkAnimation();
        GoodOrBad();
        LeanTween.scaleY(LevelController.Instance.FinishPlane, GetFinalScore()+1, 2).setOnComplete
        (
            () => GameManager.Instance.GetFinishGame()
        );
    }

    private void GoodOrBad()
    {
        if(IsProgressBarScoreGood())
        {
            Player.Instance.transform.LookAt(LevelController.Instance.MaleCharacter.transform.position);
            LevelController.Instance.MaleCharacter.transform.LookAt(Player.Instance.transform.position);

            Player.Instance.Bride();
        }
        else
        {
            Player.Instance.transform.LookAt(LevelController.Instance.MaleCharacter.transform.position);
            LevelController.Instance.MaleCharacter.transform.LookAt(-Player.Instance.transform.position);
            Player.Instance.Separation();
        }
    }

    private int GetFinalScore()
    {
        if(IsProgressBarScoreGood())
        {
            return ScoreController.Instance.GoodScore;
        }
        
        return ScoreController.Instance.BadScore;
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
