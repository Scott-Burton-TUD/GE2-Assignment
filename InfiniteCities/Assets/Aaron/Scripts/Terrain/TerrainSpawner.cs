using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TerrainSpawner : MonoBehaviour
{
    public string prefabFolderName = "Prefabs"; // the name of the folder that holds the prefabs
    public bool spawnOnStart = true; // whether to spawn a prefab on Start

    void Start()
    {
        if (spawnOnStart)
        {
            SpawnPrefab();
        }
    }

    public void SpawnPrefab()
    {
        GameObject[] prefabs = Resources.LoadAll<GameObject>(prefabFolderName); // load all the prefabs in the folder
        if (prefabs.Length > 0)
        {
            int randomIndex = Random.Range(0, prefabs.Length); // generate a random index
            GameObject prefabToSpawn = prefabs[randomIndex]; // select the prefab to spawn
            Instantiate(prefabToSpawn, transform.position, Quaternion.identity); // spawn the prefab
        }
        else
        {
            Debug.LogWarning("No prefabs found in folder: " + prefabFolderName);
        }
    }
}