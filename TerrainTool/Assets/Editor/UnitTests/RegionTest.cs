using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class RegionTest {

	[Test]
	public void CalculateRegionWhenAtZeroPositionTest()
	{
        //create a 100x100 terrain with a 513x513 heightmap
        TerrainData td = new TerrainData();
        td.size = new Vector3(500f, 0f, 500f);
        td.heightmapResolution = 513;
        GameObject go = Terrain.CreateTerrainGameObject(td);
        go.transform.position = Vector3.zero;
        Terrain terrain = go.GetComponent<Terrain>();
        //assume constraint being 100x100 units large
        float width = 100f;
        float length = 100f;
        //assume being at zero position taking into account the dimensions
        Vector3 position = new Vector3(50f, 0, 50f);
        
        //region of the heightmap
        Region r = Region.CalculateRegion(position, width, length, terrain);

        //assumptions:
        //looking onto the x-z plane (along y downwards)
        //z points to right
        //x points down
        //thus, the affected heightmap region must have the following values:
        //x-start: (pos.x - width/2)/terrain.size.x *hmreso == (50 - 50)/500 *513 = 0
        //y-start: (pos.y - length/2)/terrain.size.y *hmreso == (50 - 50)/500 *513 = 0
        //x-end: ((pos.x + width/2)/terrain.size.x)*hmresolution == ((50 + 50)/500)*513 = 100/500*513 = 0.2*513 = 102,6 -> 102
        //y-end: ((pos.y + length/2)/terrain.size.y)*hmresolution == ((50 + 50)/500)*513 = 100/500*513 = 0.2*513 = 102,6 -> 102
        //xcount: xend - xstart = 102 - 0 = 102
        //ycount: yend - ystart = 102 - 0 = 102
        Assert.AreEqual(0, r.X);
        Assert.AreEqual(0, r.Y);
        Assert.AreEqual(102, r.XCount);
        Assert.AreEqual(102, r.YCount);

	}
}
