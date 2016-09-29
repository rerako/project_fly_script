using UnityEngine;
using System.Collections;

public class meshMaker : MonoBehaviour
{
    public Vector3[] newVertices;
    public Vector2[] uvs;

    public int[] newTriangles;

    void Start()
    {
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        mesh.name = "ScriptedMesh";
        /*
        newVertices = new Vector3[] {
         new Vector3(-1, -1, 0.01f),
         new Vector3(1, -1, 0.01f),
         new Vector3(1, 1, 0.01f),
         new Vector3(-1, 1, 0.01f),
         new Vector3(1, -1f, 3.01f) };*/
        mesh.vertices = newVertices;
        uvs = new Vector2[newVertices.Length];

        for (int i = 0; i < uvs.Length; i++)
        {
            uvs[i] = new Vector2(newVertices[i].x, newVertices[i].z);
        }

        mesh.uv = uvs;

        mesh.triangles = newTriangles;
        // 0, 1, 2, 0, 2, 3, 3, 1 , 0 , 1,2,3
    }

}