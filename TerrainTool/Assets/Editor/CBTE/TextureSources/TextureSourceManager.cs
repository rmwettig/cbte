
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class TextureSourceManager : ScriptableObject
{
	private Dictionary<int,int> _referenceCount
	{
		get;
		set;
	}

	public virtual TextureSource FindSourceByName(string name)
	{
		throw new System.NotImplementedException();
	}

	public virtual TextureSource CreateTextureSource()
	{
		throw new System.NotImplementedException();
	}

	public virtual TextureSource Duplicate(string name)
	{
		throw new System.NotImplementedException();
	}

	public virtual TextureSource[] GetTextureSources()
	{
		throw new System.NotImplementedException();
	}

	public virtual void OnDisable()
	{
		throw new System.NotImplementedException();
	}

}

