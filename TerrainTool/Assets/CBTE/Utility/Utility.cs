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
    /// <returns>floored and clamped index</returns>
    public static int TransformWorldToTextureArrayCoordinates(float terrainStart, float terrainEnd, float value, int heightMapResolution)
    {
        float normalizedDistance = value/(terrainEnd-terrainStart);
        float f = normalizedDistance * heightMapResolution;
        return Mathf.Clamp(Mathf.FloorToInt(f), 0, heightMapResolution);
    }

    /// <summary>
    /// Calculates border values
    /// </summary>
    /// <param name="dimension">size on a specific axis</param>
    /// <param name="position">center of mass on the specific axis</param>
    /// <param name="min">axis minimum</param>
    /// <param name="max">axis maximum</param>
    /// <param name="lowerLimit">calculated lower limit</param>
    /// <param name="upperLimit">calculated upper limit</param>
    public static void CalculateLimits(float dimension, float position, float min, float max, out float lowerLimit, out float upperLimit)
    {
        float half = dimension * 0.5f;
        lowerLimit = Mathf.Max(position - half, min);
        upperLimit = Mathf.Min(position + half, max);
    }
}
