using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class CombineMesh : MonoBehaviour
{
    public void CombineChildMeshes()
    {
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Length-1];
        for (int i = 0; i < combine.Length; i++)
        {
            combine[i].mesh = meshFilters[i+1].sharedMesh;
            combine[i].transform = meshFilters[i+1].transform.localToWorldMatrix;
            meshFilters[i+1].gameObject.SetActive(false);
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