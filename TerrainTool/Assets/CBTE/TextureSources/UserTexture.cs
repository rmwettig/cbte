
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

public class UserTexture : TextureSource
{
    /// <summary>
    /// Accesses the specified texture without additional memory allocation
    /// </summary>
    /// <returns>reference to the user-specified texture</returns>
	public override Texture2D CreateTexture()
	{
        return _texture;
	}


    public override void DrawInspectorUI(ConstraintsContext context)
    {
        base.DrawInspectorUI(context);
        _texture = EditorGUILayout.ObjectField("Heightmap", _texture, typeof(Texture2D)) as Texture2D;
    }

    private void OnEnable()
    {
        SetName("UserTexture");
    }
}

