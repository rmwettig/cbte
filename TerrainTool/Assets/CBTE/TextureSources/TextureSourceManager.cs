
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

	public TextureSource FindSourceByName(string name)
	{
		throw new System.NotImplementedException();
	}

	public TextureSource CreateTextureSource()
	{
		throw new System.NotImplementedException();
	}

	public TextureSource Duplicate(string name)
	{
		throw new System.NotImplementedException();
	}

	public TextureSource[] GetTextureSources()
	{
		throw new System.NotImplementedException();
	}

	public void OnDisable()
	{
        Debug.Log("Not yet implemented");
	}

}

