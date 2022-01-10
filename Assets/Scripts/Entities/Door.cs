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
    }
}
