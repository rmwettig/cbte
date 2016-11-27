using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class UtilityTest
{

    [Test]
    public void CalculateLimitsWithinBounds()
    {
        //assume a position of 200u at any axis
        float position = 200f;
        float min, max;
        Utility.CalculateLimits(100f, position, 0f, 500f, out min, out max);

        Assert.AreEqual(150f, min);
        Assert.AreEqual(250f, max);
    }

    [Test]
    public void CalculateLimitsExceedingLowerBound()
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
    public void CalculateLimitsExceedingUpperBound()
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
    public void CalculateLimitsExceedingBothBounds()
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
}
