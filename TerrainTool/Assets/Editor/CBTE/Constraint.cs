
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

	public virtual void SetColor(Color color)
	{
		throw new System.NotImplementedException();
	}

	public virtual void SetName(string name)
	{
		throw new System.NotImplementedException();
	}

	public virtual void DrawInspectorUI(object AppContext)
	{
		throw new System.NotImplementedException();
	}

	public virtual void DrawSceneUI()
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

