using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TerrainSpawner : MonoBehaviour
{
    public string prefabFolderName = "Prefabs"; // the name of the folder that holds the prefabs
    public float spawnInterval = 5f; // the time interval between spawns
    private GameObject spawnedPrefab; // the reference to the spawned prefab

    public float fadeTime = 1f; // the time it takes for the prefab to fade in/out



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
                StartCoroutine(FadeOutAndDestroy(spawnedPrefab)); // fade out and destroy the previously spawned prefab
            }
            spawnedPrefab = Instantiate(prefabToSpawn, transform.position, Quaternion.identity); // spawn the prefab
            spawnedPrefab.transform.parent = transform; // make the spawned prefab a child of this game object
            StartCoroutine(FadeIn(spawnedPrefab)); // fade in the spawned prefab
        }
        else
        {
            Debug.LogWarning("No prefabs found in folder: " + prefabFolderName);
        }
    }

    private IEnumerator FadeOutAndDestroy(GameObject obj)
    {
        // fade out the object
        float elapsedTime = 0;
        while (elapsedTime < fadeTime)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeTime);
            Color color = obj.GetComponent<Renderer>().material.color;
            color.a = alpha;
            obj.GetComponent<Renderer>().material.color = color;
            yield return null;
        }

        // destroy the object
        Destroy(obj);
    }

    private IEnumerator FadeIn(GameObject obj)
    {
        // fade in the object
        float elapsedTime = 0;
        while (elapsedTime < fadeTime)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeTime);
            Color color = obj.GetComponent<Renderer>().material.color;
            color.a = alpha;
            obj.GetComponent<Renderer>().material.color = color;
            yield return null;
        }
    }
}