using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helpers;

public class Player : MonoSingleton<Player>
{
    #region Variables
    [SerializeField] private PlayerSettings playerSettings;

    [SerializeField] private Animator playerAnimator;
    [SerializeField] private Animator loveAnimator;

    public bool OnFinishPlane = false;
    
    private bool canMove = false;

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
            playerAnimator.SetTrigger("Walk");
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
        playerAnimator.ResetTrigger("Walk");
    }


    #endregion

    #region Callbacks

    private void OnStartGame()
    {
        canMove = true;
    }

    private void OnNextLevel()
    {
        OnFinishPlane = false;
        transform.position = Vector3.zero;
        transform.LookAt(transform.position + new Vector3(0,0,1));

        canMove = true;

        playerAnimator.ResetTrigger("Chicken");
        playerAnimator.ResetTrigger("Belly");

        loveAnimator.ResetTrigger("Chicken");
        loveAnimator.ResetTrigger("Sad");
    }

    private void OnFinishGame()
    {
        canMove = false;
    }

    public void Bride() 
    {
        playerAnimator.SetTrigger("Chicken");
        loveAnimator.SetTrigger("Chicken");
    }
    public void Separation() 
    {
        playerAnimator.SetTrigger("Belly");
        loveAnimator.SetTrigger("Sad");
    }
    #endregion
}
