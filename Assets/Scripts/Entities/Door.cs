using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] 
    private int doorPoint;

    public bool isLuckDoor = false;

    private void LuckDoor()
    {
        int goodOrBad = Random.Range(0,1);
        if(goodOrBad == 0)
        {
            doorPoint *= -1;
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(isLuckDoor)
        {
            LuckDoor();
        }
        ScoreController.Instance.ProgressScore += doorPoint;
        LeanTween.scale(gameObject,Vector3.zero,.5f);

        if (doorPoint > 0)
        {
            LeanTween.scale(ProgressBar.Instance.GoodSprite,Vector3.one*1.2f,.15f).setLoopPingPong(2);
        }
        else
        {
            LeanTween.scale(ProgressBar.Instance.BadSprite,Vector3.one*1.2f,.15f).setLoopPingPong(2);
        }
    }
}
