using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCollectable : MonoBehaviour
{
    

    private void OnTriggerEnter(Collider other) 
    {
        gameObject.SetActive(false);
        Increase();
    }

    protected virtual void Increase()
    {
        //maybe collectable sound
    }
}
