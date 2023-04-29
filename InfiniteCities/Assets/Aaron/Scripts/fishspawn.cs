using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishspawn : MonoBehaviour
{
    public GameObject[] prefabsToSpawn;
    public int numPrefabsToSpawn = 10;
    public Vector3 boxSize = new Vector3(10f, 10f, 10f);
    public Color gizmoColor = Color.white;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireCube(transform.position, boxSize);
    }

    private void Start()
    {
        for (int i = 0; i < numPrefabsToSpawn; i++)
        {
            Vector3 spawnPos = transform.position + new Vector3(Random.Range(-boxSize.x / 2f, boxSize.x / 2f),
                                                                Random.Range(-boxSize.y / 2f, boxSize.y / 2f),
                                                                Random.Range(-boxSize.z / 2f, boxSize.z / 2f));
            GameObject prefab = prefabsToSpawn[Random.Range(0, prefabsToSpawn.Length)];
            Quaternion randomRotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);
            GameObject spawnedPrefab = Instantiate(prefab, spawnPos, randomRotation);
            spawnedPrefab.transform.parent = transform;
        }
    }
}
