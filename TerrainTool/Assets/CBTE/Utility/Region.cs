using UnityEngine;
using System.Collections;

/// <summary>
/// Holds affected terrain heightmap section coordinates
/// </summary>
public class Region : ScriptableObject
{
    private int _x = 0;
    private int _y = 0;
    private int _xCount = 0;
    private int _yCount = 0;

    public int X { get { return _x; } }
    public int Y { get { return _y; } }
    public int XCount { get { return _xCount; } }
    public int YCount { get { return _yCount; } }

    public static Region CalculateRegion(Vector3 position, Terrain terrain)
    {

    }
}
