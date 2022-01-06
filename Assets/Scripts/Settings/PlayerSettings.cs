using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Player Settings")]
public class PlayerSettings : ScriptableObject
{
    public float forwardSpeed;
    public float swerweSpeed;
    public float minXPos;
    public float maxXpos;
}
