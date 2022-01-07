using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionControl : MonoBehaviour
{
    #region Variables
    private int point = 0;
    #endregion

    #region Unity Methods
    private void OnTriggerEnter(Collider other)
    {
        //Silinecek bir alttaki if bloðu
        //if (other.name == "FinishPoint")
        //{
        //    GameManager.Instance.GetFinishGame();
        //    //LevelController.Instance.GetNextLevel();
        //}
        if (other.gameObject.GetComponent<Portals>().portalType == Portals.PortalType.negativePortal)
        {
            //negative point
            point -= 15;
            Debug.Log(point);
        }
        if (other.gameObject.GetComponent<Portals>().portalType == Portals.PortalType.positivePortal)
        {
            //positive point
            point += 14;
        }
        if (other.gameObject.GetComponent<Portals>().portalType == Portals.PortalType.finish)
        {
            GameManager.Instance.GetFinishGame();
            //LevelController.Instance.GetNextLevel();
        }
        //CollectableObjects için iki if bloðu daha yazýlacak (negative8puan positive9puan)
    }
    #endregion
}
