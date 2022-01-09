using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helpers;

public class Player : MonoSingleton<Player>
{
    #region Variables
    [SerializeField] private PlayerSettings playerSettings;

    [SerializeField] private Animator animator;
    private bool canMove = false;
    public bool OnFinishPlane = false;

    private float touchPosX;

    #endregion

    #region Unity Methods

    private void Start()
    {
        LevelController.Instance.NextLevel += OnNextLevel;
        GameManager.Instance.FinishGame += OnFinishGame;
        GameManager.Instance.StartGame += OnStartGame;
        OnFinishPlane = false;
    }

    void Update()
    {
        if (GameManager.Instance.IsGameStart && canMove && !OnFinishPlane)
        {
            Movement();
            animator.SetTrigger("Walk");
        }
    }
    
    #endregion

    #region Methods

    private void Movement()
    {

        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            touchPosX += touch.deltaPosition.x * playerSettings.swerweSpeed * Time.deltaTime;
        }

        transform.position = new Vector3
        (
            Mathf.Clamp(touchPosX, playerSettings.minXPos, playerSettings.maxXpos),
            transform.position.y,
            transform.position.z + playerSettings.forwardSpeed * Time.deltaTime
        );
    }

    public void ResetWalkAnimation()
    {
        animator.ResetTrigger("Walk");
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
