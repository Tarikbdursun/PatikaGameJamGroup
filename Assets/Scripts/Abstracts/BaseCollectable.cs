using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCollectable : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Increase();
    }

    protected virtual void Increase()
    {

    }
}
