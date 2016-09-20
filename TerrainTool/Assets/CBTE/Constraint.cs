
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

public class Constraint : ScriptableObject, Colorizable, Nameable, Inspectable, Displayable, Visibility, Freezable
{
    public event ConstraintChangedEvent Up;
    public event ConstraintChangedEvent Down;
    public event ConstraintChangedEvent Delete;
    public event ConstraintChangedEvent Change;

    private TextureSource _textureSource;

    private float[,] _previousHeights;

    private float _rotationAngle;

    private float _strength;

    private bool _isFrozen;
    private string _name;
    private Vector3 _position = Vector3.zero;
    private Vector3 _dimension = new Vector3(100f, 0, 100f);
    private float _length = 100f;
    private float _width = 100f;
    private Color _color = Color.white;


    #region Inspector UI state
    private bool _isOpen = false;
    #endregion Inspector UI state

    public void SetColor(Color color)
	{
        _color = color;
	}

	public void SetName(string name)
	{
        _name = name;
	}

    public void DrawInspectorUI(ConstraintsContext context)
	{
        _isOpen = EditorGUILayout.Foldout(_isOpen, _name);
        if(_isOpen)
        {
            EditorGUILayout.BeginVertical();
            EditorGUI.indentLevel++;
            _color = EditorGUILayout.ColorField("Outline color", _color);
            _position = EditorGUILayout.Vector3Field("Position", _position, GUILayout.MaxWidth(200f));
            UpdateDimensions();

            EditorGUI.indentLevel--;
            EditorGUILayout.EndVertical();

            if(GUI.changed)
            {
                EditorUtility.SetDirty(context);
                if (Change != null) Change(this);
            }
        }
	}

    private void UpdateDimensions()
    {
        _width = EditorGUILayout.FloatField("Width", _width, GUILayout.MaxWidth(200f));
        _length = EditorGUILayout.FloatField("Length", _length, GUILayout.MaxWidth(200f));
        _dimension = new Vector3(_width, 0, _length);
    }

	public void DrawGizmo()
	{
        Color oldColor = Gizmos.color;
        Gizmos.color = _color;
        Gizmos.DrawWireCube(_position, _dimension);
        Gizmos.color = oldColor;
	}

	public virtual void Toggle()
	{
		throw new System.NotImplementedException();
	}

	public virtual void Freeze()
	{
		throw new System.NotImplementedException();
	}

	public virtual void Apply(object Terrain)
	{
		throw new System.NotImplementedException();
	}

	public virtual void Undo(object Terrain)
	{
		throw new System.NotImplementedException();
	}

    public void DrawTransformHandle(UnityEngine.Object target, float xMin, float xMax, float zMin, float zMax)
    {
        _position = Handles.PositionHandle(_position, Quaternion.identity);
        //clamp positive x direction
        float half = _width / 2;
        float thres = xMax - half;
        if (_position.x > thres)
            _position.x = thres;

        //clamp negative x
        thres = xMin + half;
        if (_position.x < thres)
            _position.x = thres;
        half = _length / 2;

        //clamp positive z direction
        thres = zMax - half;
        if (_position.z > thres)
            _position.z = thres;

        //clamp negative z direction
        thres = zMin + half;
        if (_position.z < thres)
            _position.z = thres;

        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
        }
    }
}

