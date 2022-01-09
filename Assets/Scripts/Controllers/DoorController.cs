using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField]
    [Range(0,2)]
    private int spriteIndex;

    [SerializeField]
    private Transform spriteParentGood;

    [SerializeField]
    private Transform spriteParentBad;

    private void Start() 
    {   
        ActivateSprite(spriteIndex);
    }

    private void ActivateSprite(int i)
    {
        for (int a = 0; a < 3; a++)
        {
            spriteParentBad.GetChild(a).gameObject.SetActive(false);
            spriteParentGood.GetChild(a).gameObject.SetActive(false);
        }
        spriteParentBad.GetChild(i).gameObject.SetActive(true);
        spriteParentGood.GetChild(i).gameObject.SetActive(true);
        
    }
}
