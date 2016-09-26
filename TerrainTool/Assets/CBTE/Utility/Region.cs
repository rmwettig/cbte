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

    public void Initialize(int x, int y, int xcount, int ycount)
    {
        _x = x;
        _y = y;
        _xCount = xcount;
        _yCount = ycount;
    }

    public static Region CalculateRegion(Vector3 position, float width, float length, Terrain terrain)
    {
        //get necessary information from terrain
        Vector3 terrainPosition = terrain.GetPosition();
        TerrainData td = terrain.terrainData;
        float terrainWidthEnd = terrainPosition.x + td.size.x;
        float terrainLengthEnd = terrainPosition.z + td.size.z;

        //calculate start and end position of the constraint on world xz-axes

        float xMin, xMax;
        Utility.CalculateLimits(width, position.x, terrainPosition.x, terrainWidthEnd, out xMin, out xMax);
        float zMin, zMax;
        Utility.CalculateLimits(length, position.z, terrainPosition.z, terrainLengthEnd, out zMin, out zMax);

        //calculate array section boundary
        int heightMapResolution = td.heightmapResolution;
        int arrayXStart = Utility.TransformWorldToTextureArrayCoordinates(terrainPosition.x, terrainWidthEnd, xMin, heightMapResolution);
        int arrayXEnd = Utility.TransformWorldToTextureArrayCoordinates(terrainPosition.x, terrainWidthEnd, xMax, heightMapResolution);
        int arrayYStart = Utility.TransformWorldToTextureArrayCoordinates(terrainPosition.z, terrainLengthEnd, zMin, heightMapResolution);
        int arrayYEnd = Utility.TransformWorldToTextureArrayCoordinates(terrainPosition.z, terrainLengthEnd, zMax, heightMapResolution);
        Region r = ScriptableObject.CreateInstance<Region>();
        r.Initialize(arrayXStart, arrayYStart, arrayXEnd - arrayXStart, arrayYEnd - arrayYStart);
        return r;
    }

    
}
