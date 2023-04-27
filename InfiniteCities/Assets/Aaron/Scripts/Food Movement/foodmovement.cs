using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodmovement : MonoBehaviour
{
    public float rotationSpeed = 50f;   // speed of rotation
    public float floatSpeed = 0.5f;     // speed of floating
    public float floatAmount = 0.5f;    // amount of floating

    private float startY;               // initial Y position of game object

    private void Start()
    {
        startY = transform.position.y;
    }

    private void Update()
    {
        // Rotate around the Y-axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        // Float up and down using a sine wave
        Vector3 pos = transform.position;
        pos.y = startY + floatAmount * Mathf.Sin(floatSpeed * Time.time);
        transform.position = pos;
    }
}