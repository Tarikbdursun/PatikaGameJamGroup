using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portals : MonoBehaviour
{
    public PortalType portalType;
    //Portallara ve finishgate'e eklenecek script
    public enum PortalType 
    {
        negativePortal,
        positivePortal,
        finish,
        collectable
    }
}
