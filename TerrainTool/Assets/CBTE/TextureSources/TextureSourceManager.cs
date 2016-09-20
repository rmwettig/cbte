using System.Collections.Generic;
using UnityEngine;

public class TextureSourceManager : ScriptableObject
{
    private TextureSource[] _prototypes = null;
    private TextureSource[] _textureSources = null;
    private Dictionary<TextureSource, int> _referenceCount = null;

	public TextureSource FindSourceByName(string name)
	{
		throw new System.NotImplementedException();
	}

    public TextureSource FindSourceByIndex(int index)
    {
        return _textureSources[index];
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
        return _textureSources;
	}

	public void OnDisable()
	{
        Debug.Log("Not yet implemented");
	}

    public void OnEnable()
    {
        _textureSources = new TextureSource[1];
        _referenceCount = new Dictionary<TextureSource, int>();
    }

    public void AddPrototypes(params TextureSource[] prototypes)
    {
        _prototypes = prototypes;
    }

    private TextureSource[] RebuildSources()
    {
        TextureSource[] arr = new TextureSource[_referenceCount.Keys.Count];
        int i = 0;
        foreach(KeyValuePair<TextureSource, int> kv in _referenceCount)
        {
            arr[i++] = kv.Key;
        }
        return arr;
    }
}

