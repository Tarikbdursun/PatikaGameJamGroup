using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helpers;

public class CameraController : MonoSingleton<CameraController>
{

    [SerializeField]
    private GameObject target;

    [SerializeField]
    private GameObject startCamera;

    [SerializeField]
    private GameObject inGameCamera;
    
    [SerializeField]
    private GameObject finishCamera;
    private Vector3 offset;

    private void Start() {
        GameManager.Instance.StartGame += OnStartGame;

        LevelController.Instance.NextLevel += OnNextLevel;
        offset = inGameCamera.transform.position - target.transform.position;
        OnNextLevel();
    }
    void Update()
    {
        inGameCamera.transform.position = new Vector3(inGameCamera.transform.position.x, offset.y + target.transform.position.y, offset.z + target.transform.position.z);
    }

    private void OnNextLevel()
    {
        startCamera.SetActive(true);
        finishCamera.SetActive(false);
        inGameCamera.SetActive(false);
    }

    private void OnStartGame()
    {
        startCamera.SetActive(false);
        finishCamera.SetActive(false);
        inGameCamera.SetActive(true);
    }

}
