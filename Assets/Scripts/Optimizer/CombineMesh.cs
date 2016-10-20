using UnityEngine;
using System.Linq;
using System.Collections.Generic;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class CombineMesh : MonoBehaviour
{
    public void CombineChildMeshes()
    {
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];
        int i = 0;
        while (i < meshFilters.Length)
        {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = Matrix4x4.identity;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            meshFilters[i].gameObject.SetActive(false);
            i++;
        }
        Mesh mesh = new Mesh();
        mesh.CombineMeshes(combine, true);
        Vector3[] vertices = mesh.vertices;
        for (int v = 0; v < vertices.Length; v++)
        {
            vertices[v] = transform.InverseTransformPoint(vertices[v]);
        }
        mesh.vertices = vertices;
        transform.GetComponent<MeshFilter>().mesh = mesh;
        transform.GetComponent<MeshFilter>().mesh.RecalculateBounds();
        transform.GetComponent<MeshFilter>().mesh.RecalculateNormals();
        transform.GetComponent<MeshFilter>().mesh.Optimize();
        transform.GetComponent<MeshRenderer>().materials = transform.GetComponentInChildren<MeshRenderer>().materials;
        transform.gameObject.SetActive(true);
    }
}