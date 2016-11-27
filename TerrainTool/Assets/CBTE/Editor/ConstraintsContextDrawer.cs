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
        if (_context.Constraints != null)
        {
            RegisterAtConstraints(_context.Constraints); 
        }
    }

    private void OnDisable()
    {
        DeregisterAtConstraints();
    }

    public override void OnInspectorGUI()
    {
        DrawMenuBar();
        DrawConstraintUI();
    }

    /// <summary>
    /// Draws the constraint handles
    /// </summary>
    private void OnSceneGUI()
    {
        List<Constraint> constraints = _context.Constraints;
        Vector3 terrainPos = _context.Terrain.GetPosition();
        float width = _context.Terrain.terrainData.size.x;
        float length = _context.Terrain.terrainData.size.z;

        for (int i = 0; i < constraints.Count; i++)
        {
            constraints[i].DrawTransformHandle(target, terrainPos.x, terrainPos.x + width,
                terrainPos.z, terrainPos.z + length);
        }
    }

    #region InspectorHelpers

    private void DrawMenuBar()
    {
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Add"))
        {
            Constraint c = ScriptableObject.CreateInstance<Constraint>();
            c.SetName("Constraint (" + _context.Constraints.Count + ")");
            RegisterCallbacks(c);
            _context.Constraints.Add(c);
            EditorUtility.SetDirty(target);
        }
        if (GUILayout.Button("Apply"))
        {

        }
        EditorGUILayout.EndHorizontal();
    }

    /// <summary>
    /// Calls the inspector ui render method for each constraint
    /// </summary>
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

    /// <summary>
    /// Iterates over all constraints and adds event callbacks
    /// </summary>
    private void RegisterAtConstraints(List<Constraint> constraints)
    {
        for (int i = 0; i < constraints.Count; i++)
        {
            Constraint c = constraints[i];
            if (c != null)
            {
                RegisterCallbacks(c); 
            }
        }
    }

    /// <summary>
    /// Iterates over all constraints and removes event callbacks
    /// </summary>
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
        c.Change += OnConstraintChanged;
    }
    private void DeregisterCallbacks(Constraint c)
    {
        c.Down -= OnConstraintDown;
        c.Up -= OnConstraintUp;
        c.Delete -= OnConstraintDelete;
        c.Change -= OnConstraintChanged;

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
        constraint.Undo(_context.Terrain);
        DeregisterCallbacks(constraint);
        _context.Constraints.Remove(constraint);
        EditorUtility.SetDirty(_context);
        Debug.Log("# Constraints: " + _context.Constraints.Count);
    }

    public void OnConstraintFrozen(Constraint constraint)
    {
        throw new System.NotImplementedException();
    }

    public void OnConstraintChanged(Constraint constraint)
    {
        
    }

    #endregion
}
