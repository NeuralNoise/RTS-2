using UnityEngine;
using System.Collections;

public class TerrainTester : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Terrain myTerrain = GetComponent<Terrain>();
        TerrainData myTerrainData = new TerrainData();
        myTerrainData.heightmapResolution = 2048;
        myTerrainData.size = new Vector3(2048, 10, 2048);
        float[,] height = new float[5, 5];
        for (int y = 0; y < height.GetLength(0); y++)
        {
            for (int x = 0; x < height.GetLength(1); x++)
            {
                height[y, x] = 1f;
            }
        }
        myTerrainData.SetHeights(10, 10, height);
        myTerrain.terrainData = myTerrainData;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
