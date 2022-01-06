using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helpers;

public class Player : MonoSingleton<Player>
{
    #region Variables
    [SerializeField] private PlayerSettings playerSettings;
    private bool canMove = false;

    private float touchPosX;

    #endregion

    #region Unity Methods

    private void Start() 
    {
        LevelController.Instance.NextLevel += OnNextLevel;    
        GameManager.Instance.FinishGame += OnFinishGame;
        GameManager.Instance.StartGame += OnStartGame;
    }

    void Update()
    {
        if (GameManager.Instance.IsGameStart && canMove)
        {
            Movement();
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.name == "FinishPoint")
        {
            GameManager.Instance.GetFinishGame();
            //LevelController.Instance.GetNextLevel();
        }
    }

    #endregion

    #region Methods

    private void Movement()
    {
        if (Input.GetMouseButton(0))
        {
            touchPosX += Input.GetAxis("Mouse X") * playerSettings.swerweSpeed * Time.fixedDeltaTime;
        }

        transform.position = new Vector3
        (
            Mathf.Clamp(touchPosX, playerSettings.minXPos, playerSettings.maxXpos),
            transform.position.y,
            transform.position.z + playerSettings.forwardSpeed * Time.deltaTime
        );
    }

    #endregion

    #region Callbacks

    private void OnStartGame()
    {
        canMove = true;
    }

    private void OnNextLevel()
    {
        transform.position = Vector3.zero;
    }

    private void OnFinishGame()
    {
        canMove = false;
    }

    #endregion
}
