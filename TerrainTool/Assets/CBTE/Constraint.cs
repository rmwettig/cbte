
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

public class Constraint : ScriptableObject, Colorizable, Nameable, Inspectable, Displayable, Visibility, Freezable
{
    public event ConstraintChangedEvent Up;
    public event ConstraintChangedEvent Down;
    public event ConstraintChangedEvent Delete;
    public event ConstraintChangedEvent Change;

    [SerializeField]
    private TextureSource _textureSource = null;

    private float[,] _previousHeights = null;

    private float _rotationAngle = 0f;

    private float _strength = 1.0f;

    private bool _isFrozen = false;
    [SerializeField]
    private string _name = "";
    [SerializeField]
    private Vector3 _position = Vector3.zero;
    [SerializeField]
    private Vector3 _dimension = new Vector3(100f, 0, 100f);
    [SerializeField]
    private float _length = 100f;
    [SerializeField]
    private float _width = 100f;
    [SerializeField]
    private Color _color = Color.white;
    [SerializeField]
    private Region _region = null;

    #region Inspector UI state
    private bool _isOpen = false;
    private bool _isSettingsOpen = false;
    private bool _isTextureSourceOpen = false;
    [SerializeField]
    private int _textureSourceIndex = -1;
    #endregion Inspector UI state

    public void SetColor(Color color)
    {
        _color = color;
    }

    public void SetName(string name)
    {
        _name = name;
    }

    public void DrawInspectorUI(ConstraintsContext context)
    {
        _isOpen = EditorGUILayout.Foldout(_isOpen, _name);
        if (_isOpen)
        {
            EditorGUILayout.BeginVertical();
            EditorGUI.indentLevel++;
            DrawMenuBar();
            DrawSettingsUI();
            DrawTextureSourceUI(context);
            EditorGUI.indentLevel--;
            EditorGUILayout.EndVertical();

            if (GUI.changed)
            {
                EditorUtility.SetDirty(context);
                if (Change != null) Change(this);
            }
        }
    }

    private void DrawMenuBar()
    {
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Up", GUILayout.MaxWidth(50f)))
        {
            if (Up != null) Up(this);
        }
        if (GUILayout.Button("Down", GUILayout.MaxWidth(50f)))
        {
            if (Down != null) Down(this);
        }
        if (GUILayout.Button("Del", GUILayout.MaxWidth(50f)))
        {
            if (Delete != null) Delete(this);
        }
        EditorGUILayout.EndHorizontal();

    }

    /// <summary>
    /// Draws UI controls to change properties like color, size etc.
    /// </summary>
    private void DrawSettingsUI()
    {
        _isSettingsOpen = EditorGUILayout.Foldout(_isSettingsOpen, "Settings");
        if (_isSettingsOpen)
        {
            EditorGUI.indentLevel++;
            _name = EditorGUILayout.TextField("Name:", _name);
            _color = EditorGUILayout.ColorField("Outline color", _color);
            _position = EditorGUILayout.Vector3Field("Position", _position, GUILayout.MaxWidth(200f));
            UpdateDimensions();
            EditorGUI.indentLevel--;

        }
    }

    private void UpdateDimensions()
    {
        _width = EditorGUILayout.FloatField("Width", _width, GUILayout.MaxWidth(200f));
        _length = EditorGUILayout.FloatField("Length", _length, GUILayout.MaxWidth(200f));
        _dimension = new Vector3(_width, 0, _length);
    }

    /// <summary>
    /// Draws the inspector controls to choose another texture
    /// </summary>
    /// <param name="context"></param>
    private void DrawTextureSourceUI(ConstraintsContext context)
    {
        //draw details only if section is expanded
        _isTextureSourceOpen = EditorGUILayout.Foldout(_isTextureSourceOpen, "Texture Source");
        if (_isTextureSourceOpen)
        {
            EditorGUI.indentLevel++;
            //create a list of all available sources
            TextureSourceManager tsm = context.TextureSourceManager;
            string[] textureSourceNames = tsm.GetTextureSourcesNames();

            int oldIndex = _textureSourceIndex;
            _textureSourceIndex = EditorGUILayout.Popup(_textureSourceIndex, textureSourceNames);
            if (oldIndex != _textureSourceIndex)
            {
                _textureSource = tsm.FindSourceByIndex(_textureSourceIndex, out _textureSourceIndex);
            }
            if (_textureSource != null) _textureSource.DrawInspectorUI(context);
            EditorGUI.indentLevel--;
        }
    }

    public void DrawGizmo()
    {
        Color oldColor = Gizmos.color;
        Gizmos.color = _color;
        Gizmos.DrawWireCube(_position, _dimension);
        Gizmos.color = oldColor;
    }

    public void Toggle()
    {
        throw new System.NotImplementedException();
    }

    public void Freeze()
    {
        throw new System.NotImplementedException();
    }

    public void Apply(Terrain terrain)
    {
        _region = Region.CalculateRegion(_position, _width, _length, terrain);
        //save previous height values
        TerrainData td = terrain.terrainData;
        _previousHeights = td.GetHeights(_region.X, _region.Y, _region.XCount, _region.YCount);
        //sample height value from texture source
        float[,] heights = SampleHeights(_region, _textureSource.CreateTexture());
        //write new height values
        td.SetHeights(_region.X, _region.Y, heights);
    }

    public void Undo(Terrain terrain)
    {
        Debug.Log("TODO: undo impl");
    }

    public void DrawTransformHandle(UnityEngine.Object target, float xMin, float xMax, float zMin, float zMax)
    {
        _position = Handles.PositionHandle(_position, Quaternion.identity);
        //clamp positive x direction
        float half = _width / 2;
        float thres = xMax - half;
        if (_position.x > thres)
            _position.x = thres;

        //clamp negative x
        thres = xMin + half;
        if (_position.x < thres)
            _position.x = thres;
        half = _length / 2;

        //clamp positive z direction
        thres = zMax - half;
        if (_position.z > thres)
            _position.z = thres;

        //clamp negative z direction
        thres = zMin + half;
        if (_position.z < thres)
            _position.z = thres;

        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
        }
    }

    public string GetName()
    {
        return _name;
    }

    public void OnEnable()
    {
        //prevent that a constraint will be removed by the GC
        //hideFlags = HideFlags.HideAndDontSave;
    }

    /// <summary>
    /// Extracts greyscale values from a texture
    /// </summary>
    /// <param name="_region">section from which should be read</param>
    /// <param name="texture2D">used texture</param>
    /// <returns>2D float array</returns>
    private float[,] SampleHeights(Region _region, Texture2D texture2D)
    {
        float[,] heights = new float[_region.YCount, _region.XCount];
        Color[] greyscaleValues = texture2D.GetPixels(_region.X, _region.Y, _region.XCount, _region.YCount);
        for (int i = 0; i < _region.XCount; i++)
        {
            for (int j = 0; j < _region.YCount; j++)
            {
                Debug.Log(greyscaleValues[i + j * _region.XCount]);
                heights[j, i] = greyscaleValues[i + j * _region.XCount].grayscale;
            }
        }
        return heights;
    }
}

