using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables
    [SerializeField] private PlayerSettings playerSettings;

    private float touchPosX;

    private bool isInput;
    #endregion

    #region Singleton
    public static PlayerMovement instance;

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

    private void Awake()
    {
        InitSingleton();
    }
    #endregion
    void Start()
    {

    }


    void Update()
    {
        if (GameManager.instance.isGameStart)
        {
            Movement();
            IsInput();
        }
    }

    private void Movement()
    {

        //transform.position += Vector3.forward * playerSettings.forwardSpeed * Time.fixedDeltaTime;
        
        if (isInput)
        {
            touchPosX += Input.GetAxis("Mouse X") * playerSettings.swerweSpeed * Time.fixedDeltaTime;
        }

        transform.position = new Vector3(touchPosX, transform.position.y, transform.position.z);

        //var playerPos = transform.position + new Vector3(touchPosX, 0, 0);

        transform.position = new Vector3
                (
                    Mathf.Clamp(transform.position.x, playerSettings.minXPos, playerSettings.maxXpos),
                    transform.position.y,
                    transform.position.z
                );
    }

    private void IsInput()
    {
        if (Input.GetMouseButton(0))
        {
            isInput = true;
        }
        else
        {
            isInput = false;
        }
    }
}
