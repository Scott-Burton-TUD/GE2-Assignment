using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seaweed : MonoBehaviour
{
    public int numSegments = 10;  // Number of segments in the seaweed
    public float segmentLength = 0.5f;  // Length of each segment
    public float amplitude = 0.1f;  // Maximum amplitude of the wave
    public float frequency = 0.5f;  // Frequency of the wave
    public float speed = 1f;  // Speed of the wave
    public float rotationSpeed = 30f;  // Speed of the rotation
    public GameObject cubePrefab;  // Prefab to use for each segment

    private GameObject[] segments;  // Array to hold each segment
    private Vector3[] originalPositions;  // Array to hold the original positions of each segment

    void Start()
    {
        // Initialize the segments array and originalPositions array
        segments = new GameObject[numSegments];
        originalPositions = new Vector3[numSegments];

        // Generate the seaweed
        for (int i = 0; i < numSegments; i++)
        {
            GameObject segment = Instantiate(cubePrefab, transform);
            segment.transform.localPosition = new Vector3(0f, i * segmentLength, 0f);
            segments[i] = segment;
            originalPositions[i] = segment.transform.localPosition;
        }
    }

    void Update()
    {
        // Move each segment up and down based on a sine wave
        for (int i = 0; i < numSegments; i++)
        {
            GameObject segment = segments[i];
            Vector3 originalPosition = originalPositions[i];
            Vector3 newPosition = originalPosition + new Vector3(
                amplitude * Mathf.Sin((Time.time + i * frequency) * speed),
                amplitude * Mathf.Cos((Time.time + i * frequency) * speed),
                0f
            );
            segment.transform.localPosition = newPosition;
        }

        // Rotate the entire seaweed
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
