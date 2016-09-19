
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class TextureSource : ScriptableObject, Inspectable, Nameable
{
	private Texture2D _texture
	{
		get;
		set;
	}

	private string _label
	{
		get;
		set;
	}

	public abstract Texture2D CreateTexture();

	public abstract void DrawInspectorUI(object AppContext);

	public virtual void SetName(string name)
	{
		throw new System.NotImplementedException();
	}

}

