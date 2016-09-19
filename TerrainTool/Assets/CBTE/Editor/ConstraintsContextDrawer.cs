using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(ConstraintsContext))]
public class ConstraintsContextDrawer : Editor
{

    private void OnEnable()
    {
    }

    private void OnDisable()
    {

    }

    public override void OnInspectorGUI()
    {
        DrawMenuBar();
    }

    private void OnSceneGUI()
    {

    }

    #region InspectorHelpers

    private void DrawMenuBar()
    {
        EditorGUILayout.BeginHorizontal();
        if(GUILayout.Button("Add"))
        {

        }
        if(GUILayout.Button("Apply"))
        {

        }
        EditorGUILayout.EndHorizontal();

    }

    #endregion
}
