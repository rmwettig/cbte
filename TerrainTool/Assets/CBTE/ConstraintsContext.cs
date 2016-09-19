
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class ConstraintsContext : MonoBehaviour
{
	private Terrain _terrain
	{
		get;
		set;
	}

	public virtual TextureSourceManager TextureSourceManager
	{
		get;
		set;
	}

	public virtual IEnumerable<Constraint> Constraint
	{
		get;
		set;
	}

	public virtual void OnConstraintUp(Constraint constraint)
	{
		throw new System.NotImplementedException();
	}

    public virtual void OnConstraintDown(Constraint constraint)
	{
		throw new System.NotImplementedException();
	}

    public virtual void OnConstraintDelete(Constraint constraint)
	{
		throw new System.NotImplementedException();
	}

    public virtual void OnConstraintFrozen(Constraint constraint)
	{
		throw new System.NotImplementedException();
	}

	public virtual void OnSceneGUI()
	{
		throw new System.NotImplementedException();
	}

	public virtual void OnInspectorGUI()
	{
		throw new System.NotImplementedException();
	}

}

