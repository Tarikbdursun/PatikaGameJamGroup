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

    [SerializeField]
    private GameObject spriteLuck;

    private void Start() 
    {   
        ActivateSprite(spriteIndex);
        LuckDoorActivate();
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
    private void LuckDoorActivate()
    {
        var childs = GetComponentsInChildren<Door>();

        if(childs[0].isLuckDoor)
        {
            Instantiate(spriteLuck,childs[0].transform.GetChild(0).transform.position,Quaternion.identity,transform);
            
            childs[0].transform.GetChild(0).gameObject.SetActive(false);
        }
        if(childs[1].isLuckDoor)
        {
            Instantiate(spriteLuck,childs[1].transform.GetChild(0).transform.position,Quaternion.identity,transform);
            childs[1].transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
