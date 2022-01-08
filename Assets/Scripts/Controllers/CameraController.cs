using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helpers;

public class CameraController : MonoSingleton<CameraController>
{
    [SerializeField] private GameObject target;

    Vector3 offset;
    
    void Start()
    {
        offset = transform.position - target.transform.position;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, offset.z + target.transform.position.z);
    }
}
