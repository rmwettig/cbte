using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class UtilityTest
{

    [Test]
    public void CalculateLimitsWithinBoundsTest()
    {
        //assume a position of 200u at any axis
        float position = 200f;
        float min, max;
        Utility.CalculateLimits(100f, position, 0f, 500f, out min, out max);

        Assert.AreEqual(150f, min);
        Assert.AreEqual(250f, max);
    }

    [Test]
    public void CalculateLimitsExceedingLowerBoundTest()
    {
        //assume a position of 200u at any axis
        float position = 40f;
        float min, max;
        Utility.CalculateLimits(100f, position, 0f, 500f, out min, out max);

        //expectations:
        //left limit: pos - dimension/2 = 40f - 50f = -10f -> 0f;
        //upper limit: pos + dimension/2 = 40f + 50f = 90f

        Assert.AreEqual(0f, min);
        Assert.AreEqual(90f, max);
    }

    [Test]
    public void CalculateLimitsExceedingUpperBoundTest()
    {
        //assume a position of 200u at any axis
        float position = 460f;
        float min, max;
        Utility.CalculateLimits(100f, position, 0f, 500f, out min, out max);

        //expectations:
        //left limit: pos - dimension/2 = 460f - 50f = 410f
        //upper limit: pos + dimension/2 = 460f + 50f = 510f -> 500f

        Assert.AreEqual(410f, min);
        Assert.AreEqual(500f, max);
    }

    [Test]
    public void CalculateLimitsExceedingBothBoundsTest()
    {
        //assume a position of 200u at any axis
        float position = 40;
        float min, max;
        Utility.CalculateLimits(100f, position, 0f, 80f, out min, out max);

        //expectations:
        //left limit: pos - dimension/2 = 40 - 50f = -10 -> 0
        //upper limit: pos + dimension/2 = 40 + 50f = 90 -> 80

        Assert.AreEqual(0f, min);
        Assert.AreEqual(80f, max);
    }

    [Test]
    public void TransformWorldToTextureCoordinatesTest()
    {
        float terrainStart = 0f;
        float terrainEnd = 500f;
        float position = 250f;
        int heightMapResolution = 513;

       int result = Utility.TransformWorldToTextureArrayCoordinates(terrainStart, terrainEnd, position, heightMapResolution);

        //expectations:
        //first: lerping between terrainStart and terrainEnd using position as the lerp factor
        //      0 + (250/500) * (500-0) = 250
        //second: normalize interpolated value: v/(terrainEnd - terrainStart)
        //       250/(500-0) = 0.5
        //third: heightmapResolution * v_normalized
        //      513 * 0.5 = 256.5
        //fourth: floor for integer number
        //      256
       
       Assert.AreEqual(256, result);

    }
}
