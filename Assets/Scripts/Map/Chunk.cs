using UnityEngine;

public class Chunk : MonoBehaviour
{
    int[,,] blocs;

    public void Generate(int[,,] blocs)
    {
        this.blocs = blocs;
        int lenght = blocs.GetLength(0);
        int width = blocs.GetLength(2);
        int height = blocs.GetLength(1);
        for (int x = 1; x < lenght-1; x++)
        {
            for (int z = 1; z < width-1; z++)
            {
                for (int y = 1; y < height-1; y++)
                {
                    if(blocs[x,y,z] != 0)
                    {
                        int TOP = 0, LEFT = 0, RIGHT = 0, FRONT = 0, BACK = 0, type = -1;
                        if (y + 1 < blocs.GetLength(1))
                        {
                            TOP = blocs[x, y + 1, z];
                        }
                        if (x - 1 >= 0)
                        {
                            RIGHT = blocs[x - 1, y, z];
                        }
                        if (x + 1 < blocs.GetLength(0))
                        {
                            LEFT = blocs[x + 1, y, z];
                        }
                        if (z - 1 >= 0)
                        {
                            BACK = blocs[x, y, z -1];
                        }
                        if (z + 1 < blocs.GetLength(2))
                        {
                            FRONT = blocs[x, y, z + 1];
                        }
                        if(TOP == 0 || LEFT == 0 || RIGHT == 0 || FRONT == 00 || BACK == 0)
                        {
                            // One side
                            if (TOP == 0 && LEFT != 0 && RIGHT != 0 && FRONT != 0 && BACK != 0)
                            {
                                type = 0;
                            }
                            else if (TOP != 0 && LEFT == 0 && RIGHT != 0 && FRONT != 0 && BACK != 0)
                            {
                                type = 1;
                            }
                            else if (TOP != 0 && LEFT != 0 && RIGHT == 0 && FRONT != 0 && BACK != 0)
                            {
                                type = 2;
                            }
                            else if (TOP != 0 && LEFT != 0 && RIGHT != 0 && FRONT == 0 && BACK != 0)
                            {
                                type = 3;
                            }
                            else if (TOP != 0 && LEFT != 0 && RIGHT != 0 && FRONT != 0 && BACK == 0)
                            {
                                type = 4;
                            }

                            // 2 sides
                            else if(TOP == 0 && LEFT == 0 && RIGHT != 0 && FRONT != 0 && BACK != 0)
                            {
                                type = 5;
                            }
                            else if (TOP == 0 && LEFT != 0 && RIGHT == 0 && FRONT != 0 && BACK != 0)
                            {
                                type = 6;
                            }
                            else if (TOP == 0 && LEFT != 0 && RIGHT != 0 && FRONT == 0 && BACK != 0)
                            {
                                type = 7;
                            }
                            else if (TOP == 0 && LEFT != 0 && RIGHT != 0 && FRONT != 0 && BACK == 0)
                            {
                                type = 8;
                            }
                            else if (TOP != 0 && LEFT == 0 && RIGHT != 0 && FRONT == 0 && BACK != 0)
                            {
                                type = 9;
                            }
                            else if (TOP != 0 && LEFT == 0 && RIGHT != 0 && FRONT != 0 && BACK == 0)
                            {
                                type = 10;
                            }
                            else if (TOP != 0 && LEFT != 0 && RIGHT == 0 && FRONT == 0 && BACK != 0)
                            {
                                type = 11;
                            }
                            else if (TOP != 0 && LEFT != 0 && RIGHT == 0 && FRONT != 0 && BACK == 0)
                            {
                                type = 12;
                            }

                            // 3 sides
                            else if (TOP == 0 && LEFT == 0 && RIGHT != 0 && FRONT == 0 && BACK != 0)
                            {
                                type = 13;
                            }
                            else if (TOP == 0 && LEFT == 0 && RIGHT != 0 && FRONT != 0 && BACK == 0)
                            {
                                type = 14;
                            }
                            else if (TOP == 0 && LEFT != 0 && RIGHT == 0 && FRONT == 0 && BACK != 0)
                            {
                                type = 15;
                            }
                            else if (TOP == 0 && LEFT != 0 && RIGHT == 0 && FRONT != 0 && BACK == 0)
                            {
                                type = 16;
                            }
                            GameObject blocToInstantiate = ResourcesWrapper.LoadBlocs(blocs[x, y, z], type);
                            GameObject bloc = Instantiate(blocToInstantiate, transform) as GameObject;
                            bloc.transform.localPosition = new Vector3(x-1, y-1, z-1);
                        }
                    }
                }
            }
        }
        GetComponent<CombineMesh>().CombineChildMeshes();
    }
}