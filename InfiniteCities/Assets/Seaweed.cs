using UnityEngine;

public class Seaweed : MonoBehaviour
{
    public int numSegments = 20; // Number of segments in the seaweed
    public float segmentLength = 0.5f; // Length of each segment
    public float segmentRadius = 0.1f; // Radius of each segment
    public float maxAngle = 45f; // Maximum angle between segments
    public float maxBend = 0.1f; // Maximum amount of bending per segment
    public float noiseScale = 0.1f; // Scale of the noise used to generate the seaweed

    public GameObject segmentPrefab; // Prefab for the seaweed segments

    private Vector3[] segmentPositions; // Array to hold the positions of each segment
    private Vector3[] segmentDirections; // Array to hold the direction of each segment
    private Quaternion[] segmentRotations; // Array to hold the rotation of each segment

    void Start()
    {
        // Initialize segment position, direction, and rotation arrays
        segmentPositions = new Vector3[numSegments];
        segmentDirections = new Vector3[numSegments];
        segmentRotations = new Quaternion[numSegments];

        // Generate the seaweed segments
        for (int i = 0; i < numSegments; i++)
        {
            // Calculate the position and direction of the current segment
            Vector3 pos = i == 0 ? transform.position : segmentPositions[i - 1] + segmentDirections[i - 1] * segmentLength;
            Vector3 dir = i == 0 ? transform.up : segmentDirections[i - 1];

            // Randomly bend the segment
            float bendAmount = maxBend * Mathf.PerlinNoise(i * noiseScale, Time.time);
            Quaternion bendRotation = Quaternion.AngleAxis(bendAmount, Vector3.right);

            // Randomly rotate the segment
            float angle = Random.Range(-maxAngle, maxAngle);
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            // Combine the bend and rotation to get the final rotation
            Quaternion finalRotation = rotation * bendRotation;

            // Calculate the direction of the segment based on the final rotation
            dir = finalRotation * dir;

            // Store the segment position, direction, and rotation
            segmentPositions[i] = pos;
            segmentDirections[i] = dir;
            segmentRotations[i] = finalRotation;

            // Instantiate the segment prefab at the current position and rotation
            GameObject segment = Instantiate(segmentPrefab, pos, finalRotation, transform);

            // Scale the segment based on its position in the seaweed
            float scale = 1f - (float)i / (float)numSegments;
            segment.transform.localScale = new Vector3(scale, scale, scale) * segmentRadius * 2f;
        }
    }
}