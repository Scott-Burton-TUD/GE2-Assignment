     using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TerrainSpawner : MonoBehaviour
{
    public string folderPath; // The folder path where the prefabs are located.
    public Transform spawnPoint; // The location where the prefab should be spawned.

    private GameObject[] prefabs; // An array of prefabs to spawn.

    private void Start()
    {
        LoadPrefabs();
        SpawnRandomPrefab(); 
    }

    private void LoadPrefabs()
    {
        // Load all prefabs from the specified folder path.
        string[] prefabPaths = Directory.GetFiles(folderPath, "*.prefab");
        prefabs = new GameObject[prefabPaths.Length];

        for (int i = 0; i < prefabPaths.Length; i++)
        {
            prefabs[i] = (GameObject)Resources.Load(prefabPaths[i].Replace(".prefab", ""), typeof(GameObject));
        }
    }

    private void SpawnRandomPrefab()
    {
        // Generate a random index within the array length.
        int randomIndex = Random.Range(0, prefabs.Length);

        // Spawn the prefab at the specified location.
        Instantiate(prefabs[randomIndex], spawnPoint.position, Quaternion.identity);
    }
}