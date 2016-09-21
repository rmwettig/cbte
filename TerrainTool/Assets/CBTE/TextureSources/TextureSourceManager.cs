using System.Collections.Generic;
using UnityEngine;

public class TextureSourceManager : ScriptableObject
{
    private int _prototypeCount = 0;
    private List<TextureSource> _textureSources = null;
    private string[] _selectionNames = null;

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

    public string[] GetTextureSourcesNames()
    {
        return _selectionNames;
    }

    public void OnDisable()
    {
        Debug.Log("Not yet implemented");
    }

    public void OnEnable()
    {
        _textureSources = new List<TextureSource>();
    }

    /// <summary>
    /// Adds sources for cloning to the sources
    /// </summary>
    /// <param name="prototypes"></param>
    public void AddPrototypes(params TextureSource[] prototypes)
    {
        //if texture sources are already present
        if (_textureSources.Count < prototypes.Length)
        {
            //prototypes for creating new sources are placed in the beginning of the list
            _textureSources.AddRange(prototypes);
            _prototypeCount = prototypes.Length;
            RebuildSourceNames();
        }
    }

    /// <summary>
    /// Updates the source names used for selection
    /// </summary>
    /// <returns>array of source names</returns>
    private string[] RebuildSourceNames()
    {
        _selectionNames = new string[_textureSources.Count];
        for (int i = 0; i < _textureSources.Count; i++)
        {
            if(i < _prototypeCount)
            {
                _selectionNames[i] = "Create/" + _textureSources[i].GetName();
            }
            else
            {
                _selectionNames[i] = _textureSources[i].GetName();
            }
        }

        return _selectionNames;
    }
}

