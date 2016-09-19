
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
    private bool _isCollapsed = true;

	public virtual void SetColor(Color color)
	{
		throw new System.NotImplementedException();
	}

	public virtual void SetName(string name)
	{
		throw new System.NotImplementedException();
	}

	public void DrawInspectorUI(ConstraintsContext context)
	{
        EditorGUILayout.Foldout(_isCollapsed, _name);
        if(!_isCollapsed)
        {

        }
	}

	public virtual void DrawGizmo()
	{
		throw new System.NotImplementedException();
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

}

