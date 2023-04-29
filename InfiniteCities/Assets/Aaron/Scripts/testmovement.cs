using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testmovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float rotationSpeed = 1f;

    private Vector3 targetPosition;

    void Start()
    {
        // Set the initial target position to a random location in the map
        targetPosition = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), 0f);
    }

    void Update()
    {
        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Rotate towards the target position
        Vector3 direction = targetPosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        // If the fish has reached the target position, choose a new target position
        if (transform.position == targetPosition)
        {
            targetPosition = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), 0f);
        }
    }
}