
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class TextureSource : ScriptableObject, Inspectable, Nameable
{
    protected Texture2D _texture;

    private string _name;

	public abstract Texture2D CreateTexture();
    public abstract void DrawInspectorUI(ConstraintsContext context);

	

	public void SetName(string name)
	{
        _name = name;
	}

    public string GetName()
    {
        return _name;
    }
}

