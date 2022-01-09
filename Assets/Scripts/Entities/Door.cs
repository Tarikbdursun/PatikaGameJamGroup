using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private int doorPoint;

    private void OnTriggerEnter(Collider other) 
    {
        ScoreController.Instance.ProgressScore += doorPoint;
    }
}
