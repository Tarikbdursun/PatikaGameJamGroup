using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionControl : MonoBehaviour
{
    #region Variables
    [SerializeField] private GameObject heartPoint;
    private int point = 0;
    #endregion

    #region Unity Methods
    private void Update()
    {
        ProgressBar();
    }
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
            point -= 75;
            Debug.Log(point);
        }
        if (other.gameObject.GetComponent<Portals>().portalType == Portals.PortalType.positivePortal)
        {
            //positive point
            point += 70;
        }
        if (other.gameObject.GetComponent<Portals>().portalType == Portals.PortalType.finish)
        {
            GameManager.Instance.GetFinishGame();
            //LevelController.Instance.GetNextLevel();
        }
        if (other.gameObject.GetComponent<Portals>().portalType==Portals.PortalType.collectable)
        {
            point++;
            Destroy(other.gameObject);
        }
        //CollectableObjects için iki if bloðu daha yazýlacak (negative8puan positive9puan)
    }
    #endregion

    #region Methods
    private void ProgressBar()
    {
        Vector3 pointPosition = new Vector3(point, 0, 0);

        heartPoint.transform.localPosition = Vector3.Lerp(heartPoint.transform.localPosition, pointPosition, .1f);
        heartPoint.transform.localPosition = new Vector3(Mathf.Clamp(heartPoint.transform.localPosition.x, -286, 286),
                    0,
                    0);
    }
    #endregion
}
