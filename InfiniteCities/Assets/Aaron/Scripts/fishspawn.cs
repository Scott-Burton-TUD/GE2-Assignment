using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishspawn : MonoBehaviour
{
    public GameObject[] prefabsToSpawn;
    public int numPrefabsToSpawn = 10;
    public Vector3 boxSize = new Vector3(10f, 10f, 10f);
    public Vector3 minScale = Vector3.one;
    public Vector3 maxScale = Vector3.one;
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
            GameObject spawnedPrefab = Instantiate(prefab, spawnPos, Quaternion.identity);
            spawnedPrefab.transform.parent = transform;
            Vector3 randomScale = new Vector3(Random.Range(minScale.x, maxScale.x),
                                              Random.Range(minScale.y, maxScale.y),
                                              Random.Range(minScale.z, maxScale.z));
            spawnedPrefab.transform.localScale = randomScale;
        }
    }
}
