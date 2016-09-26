using UnityEngine;
using System.Collections;

public static class Utility
{
    /// <summary>
    /// Calculates an array index based on the position on the terrain for a specific axis
    /// </summary>
    /// <param name="terrainStart">lower terrain position limit on an axis</param>
    /// <param name="terrainEnd">upper terrain position limit on an axis</param>
    /// <param name="value">position on the world axis</param>
    /// <param name="heightMapResolution"></param>
    /// <returns>floored int array index</returns>
    public static int TransformWorldToTextureArrayCoordinates(float terrainStart, float terrainEnd, float value, float heightMapResolution)
    {
        float normalizedDistance = Mathf.Lerp(terrainStart, terrainEnd, value);
        float f = normalizedDistance * heightMapResolution;
        return Mathf.FloorToInt(f);
    }
}
