using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables
    public bool isGameStart;
    #endregion
    
    #region Singleton
    public static GameManager instance;

    private void InitSingleton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    #endregion

    private void Awake()
    {
        InitSingleton();
    }
    void Start()
    {

    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            isGameStart = true;
        }
    }
}
