
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
        CheckIfTextureIsReadable(_texture);
    }

    /// <summary>
    /// Extracts whether the texture has the read/write flag set
    /// </summary>
    /// <param name="texture">texture in question</param>
    /// <returns>value of isReadable flag</returns>
    private void CheckIfTextureIsReadable(Texture2D texture)
    {
        string path = AssetDatabase.GetAssetPath(texture.GetInstanceID());
        TextureImporter importer = AssetImporter.GetAtPath(path) as TextureImporter;
        
            if (importer != null)
            {
                if (!importer.isReadable)
                {
                    Debug.LogWarning(string.Format("Texture '{0}' is not readable.", _texture.name)); 
                }
            }
            else
            {
                Debug.LogWarning(string.Format("Cannot determine read/write status for Texture '{0}'.", _texture.name));
            }
        
    }

    private void OnEnable()
    {
        SetName("UserTexture");
    }
}

