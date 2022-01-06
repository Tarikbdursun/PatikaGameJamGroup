using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseLevel : MonoBehaviour
{
    public void LevelCompleted()
    {
        LevelController.Instance.GetNextLevel();
    }
}
