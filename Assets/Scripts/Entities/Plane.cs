using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Plane : MonoBehaviour
{
    [SerializeField]
    private Color color;
    [SerializeField]
    private Transform parent;
    [SerializeField]
    GameObject planePrefab;
    [SerializeField]
    private GameObject finishPlanePrefab;
    [SerializeField]
    int planeCount;

    public void GeneratePlane()
    {
        while (parent.childCount > 0)
        {
            if (parent.Find("PlaneMesh"))
            {
                DestroyImmediate(parent.Find("PlaneMesh").gameObject);
            }
        }

        for (int i = 0; i < planeCount; i++)
        {
            var newPlaneMesh = Instantiate(planePrefab, new Vector3(0, 0, planePrefab.transform.localScale.z * i), Quaternion.identity, parent);
            newPlaneMesh.name = "PlaneMesh";
            newPlaneMesh.transform.GetChild(0).GetComponent<Renderer>().sharedMaterial.color = color;
        }
        var finishPlaneMesh = Instantiate(finishPlanePrefab, new Vector3(0, 0, planePrefab.transform.localScale.z * planeCount),Quaternion.identity,parent);
        finishPlaneMesh.name = "PlaneMesh";
    }

}





