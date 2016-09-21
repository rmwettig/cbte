
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

public abstract class TextureSource : ScriptableObject, Inspectable, Nameable
{
    protected Texture2D _texture;

    private string _name;

	public abstract Texture2D CreateTexture();
    public virtual void DrawInspectorUI(ConstraintsContext context)
    {
        _name = EditorGUILayout.TextField(_name, GUILayout.MaxWidth(80f));
    }

	

	public void SetName(string name)
	{
        _name = name;
	}

    public string GetName()
    {
        return _name;
    }
}

