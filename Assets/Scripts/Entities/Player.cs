using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helpers;

public class Player : MonoSingleton<Player>
{
    #region Variables
    [SerializeField] private PlayerSettings playerSettings;

    private float touchPosX;

    #endregion

    #region Unity Methods

    void Update()
    {
        if (GameManager.Instance.IsGameStart)
        {
            Movement();
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.name == "FinishPoint")
        {
            LevelController.Instance.GetNextLevel();
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
}
