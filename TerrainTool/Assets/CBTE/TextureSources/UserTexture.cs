
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class UserTexture : TextureSource
{
	public override Texture2D CreateTexture()
	{
		throw new System.NotImplementedException();
	}


    public override void DrawInspectorUI(ConstraintsContext context)
    {
        base.DrawInspectorUI(context);
    }

    private void OnEnable()
    {
        SetName("UserTexture");
    }
}

