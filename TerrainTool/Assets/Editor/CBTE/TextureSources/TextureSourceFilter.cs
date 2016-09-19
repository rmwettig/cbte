using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class TextureSourceFilter : TextureSource
{
	private TextureSource _textureSource
	{
		get;
		set;
	}

	private Texture2D _texture
	{
		get;
		set;
	}

	public virtual TextureSource TextureSource
	{
		get;
		set;
	}


    public override Texture2D CreateTexture()
    {
        throw new NotImplementedException();
    }

    public override void DrawInspectorUI(object AppContext)
    {
        throw new NotImplementedException();
    }
}

