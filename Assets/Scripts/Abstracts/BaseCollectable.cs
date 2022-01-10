using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCollectable : MonoBehaviour
{
    private void Start() 
    {
        gameObject.LeanMoveLocalY(.7f,.7f).setLoopPingPong();    
        }
    
    private void OnTriggerEnter(Collider other) 
    {
        gameObject.SetActive(false);
        Increase();
    }

    protected virtual void Increase()
    {
        
    }
}
