
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Constraint : ScriptableObject, Colorizable, Nameable, Inspectable, Displayable, Visibility, Freezable
{
	private TextureSource _textureSource
	{
		get;
		set;
	}

	private float _previousHeights
	{
		get;
		set;
	}

	private float _rotationAngle
	{
		get;
		set;
	}

	private float _strength
	{
		get;
		set;
	}

	private bool _isFrozen
	{
		get;
		set;
	}

	public virtual ConstraintChangedEvent Up
	{
		get;
		set;
	}

	public virtual ConstraintChangedEvent Down
	{
		get;
		set;
	}

	public virtual ConstraintChangedEvent Delete
	{
		get;
		set;
	}

	public virtual ConstraintChangedEvent Change
	{
		get;
		set;
	}

	public virtual ConstraintChangedEvent ConstraintChangedEvent
	{
		get;
		set;
	}

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

