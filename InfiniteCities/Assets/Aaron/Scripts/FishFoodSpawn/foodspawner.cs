using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodspawner : MonoBehaviour
{
    public GameObject[] prefabsToSpawn;
    public Vector3 spawnAreaSize = Vector3.one;
    public float spawnInterval = 3f;
    public Color gizmoColor = Color.yellow;

    private float timeSinceLastSpawn;

    private void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnPrefab();
            timeSinceLastSpawn = 0f;
        }
    }

    private void SpawnPrefab()
    {
        Vector3 spawnPosition = transform.position + new Vector3(
            Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f),
            Random.Range(-spawnAreaSize.y / 2f, spawnAreaSize.y / 2f),
            Random.Range(-spawnAreaSize.z / 2f, spawnAreaSize.z / 2f));

        GameObject prefabToSpawn = prefabsToSpawn[Random.Range(0, prefabsToSpawn.Length)];
        GameObject spawnedPrefab = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity, transform);
        spawnedPrefab.name = prefabToSpawn.name + " (Spawned)";
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireCube(transform.position, spawnAreaSize);
    }
}


