using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(ConstraintsContext))]
public class ConstraintsContextDrawer : Editor
{
    private ConstraintsContext _context;

    private void OnEnable()
    {
        _context = (target as ConstraintsContext);
        RegisterAtConstraints();
    }

    private void OnDisable()
    {
        DeregisterAtConstraints();
    }

    public override void OnInspectorGUI()
    {
        DrawMenuBar();
    }

    /// <summary>
    /// Draws the constraint handles
    /// </summary>
    private void OnSceneGUI()
    {

    }

    #region InspectorHelpers

    private void DrawMenuBar()
    {
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Add"))
        {

        }
        if (GUILayout.Button("Apply"))
        {

        }
        EditorGUILayout.EndHorizontal();
    }

    private void DrawConstraintUI()
    {
        List<Constraint> constraints = _context.Constraints;
        for(int i = 0; i < constraints.Count; i++)
        {
            constraints[i].DrawInspectorUI(_context);
        }
    }

    #endregion

    #region EventHandlers

    private void RegisterAtConstraints()
    {
        List<Constraint> constraints = _context.Constraints;
        for (int i = 0; i < constraints.Count; i++)
        {
            RegisterCallbacks(constraints[i]);
        }
    }
    private void DeregisterAtConstraints()
    {
        List<Constraint> constraints = _context.Constraints;
        for (int i = 0; i < constraints.Count; i++)
        {
            DeregisterCallbacks(constraints[i]);
        }
    }

    private void RegisterCallbacks(Constraint c)
    {
        c.Down += OnConstraintDown;
        c.Up += OnConstraintUp;
        c.Delete += OnConstraintDelete;
    }
    private void DeregisterCallbacks(Constraint c)
    {
        c.Down -= OnConstraintDown;
        c.Up -= OnConstraintUp;
        c.Delete -= OnConstraintDelete;
    }

    public void OnConstraintUp(Constraint constraint)
    {
        throw new System.NotImplementedException();
    }

    public void OnConstraintDown(Constraint constraint)
    {
        throw new System.NotImplementedException();
    }

    public void OnConstraintDelete(Constraint constraint)
    {
        throw new System.NotImplementedException();
    }

    public void OnConstraintFrozen(Constraint constraint)
    {
        throw new System.NotImplementedException();
    }

    #endregion
}
