using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CursorMesh : MonoBehaviour
{
    public enum meshColor{
        yellow,
        orange,
        green,
    }

    public meshColor _meshColor;
    public Material[] materials;

    MeshRenderer meshRenderer;

    // Start is called before the first frame update
    private void Start()
    {
        Init();
    }
    
    public void Init()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();
        if (meshFilter == null)
        {
            Debug.LogError("MeshFilter not found!");
            return;
        }

        Mesh mesh = meshFilter.sharedMesh;
        if (mesh == null)
        {
            meshFilter.mesh = new Mesh();
            mesh = meshFilter.sharedMesh;
        }
        mesh.Clear();
        mesh.vertices = new Vector3[] {
            new Vector3(0, 0, -0.5f),
            new Vector3(0.5f, 0, 0),
            new Vector3(-0.5f, 0, 0),
            new Vector3(0, 0, 0.5f),
            new Vector3(0, -1f, 0),
        };
        mesh.triangles = new int[]{
            0,1,2,
            3,1,2,
            4, 0, 1,
            4, 1, 3,
            4, 3, 2,
            4, 2, 0,
        };

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        mesh.Optimize();
        SetColor(_meshColor);
    }

    // Update is called once per frame
    public void SetColor(meshColor color)
    {
        _meshColor = color;
        switch (color)
        {
            case meshColor.yellow:
                meshRenderer.material = materials[0];
                break;
            case meshColor.green:
                meshRenderer.material = materials[1];
                break;
            case meshColor.orange:
                meshRenderer.material = materials[2];
                break;
        }
    }
}
