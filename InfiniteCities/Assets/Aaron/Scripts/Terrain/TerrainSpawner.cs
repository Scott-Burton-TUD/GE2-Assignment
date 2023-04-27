using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TerrainSpawner : MonoBehaviour
{
    public string prefabFolderName = "Prefabs"; // the name of the folder that holds the prefabs
    public float spawnInterval = 5f; // the time interval between spawns
    private GameObject spawnedPrefab; // the reference to the spawned prefab

    void Start()
    {
        InvokeRepeating("SpawnPrefab", 0f, spawnInterval); // invoke the SpawnPrefab method every spawnInterval seconds
    }

    public void SpawnPrefab()
    {
        GameObject[] prefabs = Resources.LoadAll<GameObject>(prefabFolderName); // load all the prefabs in the folder
        if (prefabs.Length > 0)
        {
            int randomIndex = Random.Range(0, prefabs.Length); // generate a random index
            GameObject prefabToSpawn = prefabs[randomIndex]; // select the prefab to spawn
            if (spawnedPrefab != null)
            {
                Destroy(spawnedPrefab); // destroy the previously spawned prefab
            }
            spawnedPrefab = Instantiate(prefabToSpawn, transform.position, Quaternion.identity); // spawn the prefab
            spawnedPrefab.transform.parent = transform; // make the spawned prefab a child of this game object
        }
        else
        {
            Debug.LogWarning("No prefabs found in folder: " + prefabFolderName);
        }
    }
}