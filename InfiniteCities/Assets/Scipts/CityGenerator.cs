using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityGenerator : MonoBehaviour
{
    public GameObject cityBlockPrefab;
    public int citySize = 10;
    public float blockWidth = 10f;
    public float blockHeight = 10f;
    public float noiseScale = 0.1f;
    public float roadWidth = 2f;

    void Start()
    {
        for (int x = 0; x < citySize; x++)
        {
            for (int z = 0; z < citySize; z++)
            {
                // Instantiate city block prefab
                GameObject cityBlock = Instantiate(cityBlockPrefab, transform);

                // Position city block
                cityBlock.transform.position = new Vector3(x * blockWidth, 0f, z * blockWidth);

                // Generate building heights using Perlin noise
                MeshFilter blockMesh = cityBlock.GetComponent<MeshFilter>();
                Vector3[] vertices = blockMesh.mesh.vertices;
                for (int i = 0; i < vertices.Length; i++)
                {
                    float noise = Mathf.PerlinNoise((x + vertices[i].x) * noiseScale, (z + vertices[i].z) * noiseScale);
                    vertices[i].y = noise * blockHeight;
                }
                blockMesh.mesh.vertices = vertices;
                blockMesh.mesh.RecalculateNormals();
            }
        }
    }
}