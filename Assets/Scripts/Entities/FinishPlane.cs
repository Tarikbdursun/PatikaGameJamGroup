using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPlane : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        LeanTween.moveLocalY(Player.Instance.gameObject, 4, 2);
        Player.Instance.OnFinishPlane = true;
        Player.Instance.ResetWalkAnimation();
        LeanTween.scaleY(LevelController.Instance.FinishPlane, 5, 2).setOnComplete
        (
            () => GameManager.Instance.GetFinishGame()
        );
    }
}
