using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Plane))]
public class MapEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Plane plane = target as Plane;
        if(DrawDefaultInspector())
        {
            plane.GeneratePlane();
        }
        if(GUILayout.Button("Generate Plane"))
        {
            plane.GeneratePlane();
        }
    }
}
