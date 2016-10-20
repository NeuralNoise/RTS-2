using UnityEngine;
using System.Diagnostics;
using CielaSpike;
using System.Collections;

public class MapGenerator : MonoBehaviour {

    #region Properties
    const int CHUNK_LENGTH = 16;
    const int CHUNK_WIDTH = 16;
    const int CHUNK_HEIGHT = 8;
    const int NB_CHUNK_BEFORE_DISPLAY = 50;
    #endregion

    #region Public Methods
    public void Generate ()
    {
        int[,,] map = GenerateMapSeed(156, 16, 156);
        GenerateMap(map);
	}
    #endregion

    #region Private Methods
    void GenerateMap(int[,,] map)
    {
        StartCoroutine(c_GenerateMap(map));
    }
    int[,,] GenerateMapSeed(int length, int height ,int width)
    {
        int[,,] map = new int[length, height, width];
        for (int x = 0; x < length; x++)
        {
            for (int y = 0; y < height; y++)
            {
                for (int z = 0; z < width; z++)
                {
                    map[x, y, z] = 1;
                }
            }
        }
        return map;
    }
    int[,,] GenerateChunkSeed(int[,,] map,int x,int y,int z)
    {
        int[,,] chunkSeed = new int[CHUNK_LENGTH + 2, CHUNK_HEIGHT + 2, CHUNK_WIDTH + 2];
        int xMin = x * CHUNK_WIDTH - 1;
        int yMin = y * CHUNK_HEIGHT - 1;
        int zMin = z * CHUNK_WIDTH - 1;
        for (int xx = 0; xx < CHUNK_LENGTH + 2; xx++)
        {
            for (int yy = 0; yy < CHUNK_HEIGHT + 2; yy++)
            {
                for (int zz = 0; zz < CHUNK_WIDTH + 2; zz++)
                {
                    int X = xx + xMin;
                    int Y = yy + yMin;
                    int Z = zz + zMin;
                    if ((X < 0 || X > map.GetLength(0)-1)|| (Y < 0 || Y > map.GetLength(1) - 1)|| (Z < 0 || Z > map.GetLength(2) - 1))
                    {
                        chunkSeed[xx, yy, zz] = 0;
                    }
                    else
                    {
                        chunkSeed[xx, yy, zz] = map[xx + xMin, yy + yMin, zz + zMin];
                    }
                }
            }
        }
        return chunkSeed;
    }
    IEnumerator c_GenerateMap(int[,,] map)
    {
        Stopwatch l_stopWatch = new Stopwatch();
        l_stopWatch.Start();
        yield return Ninja.JumpBack;
        GameObject chunkPrefab = Resources.Load("Chunk") as GameObject;
        int ChunkForLenght = Mathf.CeilToInt((float)map.GetLength(0) / CHUNK_LENGTH);
        int ChunkForWidth = Mathf.CeilToInt((float)map.GetLength(2) / CHUNK_WIDTH);
        int ChunkForHeight = Mathf.CeilToInt((float)map.GetLength(1) / CHUNK_HEIGHT);
        int i = 0;
        for (int x = 0; x < ChunkForLenght; x++)
        {
            for (int y = 0; y < ChunkForHeight; y++)
            {
                for (int z = 0; z < ChunkForWidth; z++)
                {
                    GameObject chunk = Instantiate(chunkPrefab, transform) as GameObject;
                    int[,,] chunkSeed = GenerateChunkSeed(map, x, y, z);
                    chunk.GetComponent<Chunk>().Generate(chunkSeed);
                    chunk.transform.localPosition = new Vector3(CHUNK_LENGTH * x, CHUNK_HEIGHT * y, CHUNK_WIDTH * z);
                    i++;
                    if (i >= NB_CHUNK_BEFORE_DISPLAY)
                    {
                        yield return Ninja.JumpToUnity;
                        yield return Ninja.JumpBack;
                        i = 0;
                    }
                }
            }
        }
        l_stopWatch.Stop();
        UnityEngine.Debug.Log(l_stopWatch.ElapsedMilliseconds);
    }
    #endregion
}
