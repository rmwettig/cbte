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

    /// <summary>
    /// Evaluates the index obtained from the popup menu
    /// </summary>
    /// <param name="selectionIndex">menu entry index</param>
    /// <param name="listIndex">index in the list</param>
    /// <returns>null if source can not be created</returns>
    public TextureSource FindSourceByIndex(int selectionIndex, out int listIndex)
    {
        TextureSource result = null;
        listIndex = selectionIndex;
        //if user chose an index related to source creation
        if(selectionIndex < _prototypeCount)
        {
            result = CreateTextureSource(selectionIndex, out listIndex);
        }
        else
        {
            result = _textureSources[selectionIndex];
        }
        return result;
    }

    /// <summary>
    /// Creates a new texture source instance
    /// </summary>
    /// <param name="prototypeIndex">index of source prototype</param>
    /// <param name="listIndex">index of the newly created source in the list</param>
    /// <returns>null if creation failed</returns>
    private TextureSource CreateTextureSource(int prototypeIndex, out int listIndex)
    {
        TextureSource source = ScriptableObject.CreateInstance(_textureSources[prototypeIndex].GetType()) as TextureSource;
        listIndex = -1;
        if (source != null)
        {
            source.SetName(source.GetName() + " (" + _textureSources.Count + ")");
            listIndex = _textureSources.Count;
            _textureSources.Add(source);
            RebuildSourceNames();
        }
        return source;
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
        if (_textureSources == null)
        {
            _textureSources = new List<TextureSource>(); 
        }
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
    public void RebuildSourceNames()
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
    }
}

