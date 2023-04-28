using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFade : MonoBehaviour
{
    public float fadeSpeed = 1.5f;          // Speed that the object will fade in and out.

    private Renderer test;             // Reference to the Renderer component.
    private Color originalColor;           // The original color of the object.
    //private bool fadingIn = true;          // Whether the object is currently fading in or out.

    void Start()
    {
        // Get the Renderer component of the object.
        test = GetComponent<Renderer>();
        // Store the original color of the object.
        originalColor = test.material.color;
    }

    void Update()
    {
        // Calculate the alpha value for the object's color based on the current time.
        float alpha = Mathf.PingPong(Time.time * fadeSpeed, 1f);
        // Create a new color with the same RGB values as the original color, but with the alpha set to the calculated value.
        Color newColor = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
        // Set the object's color to the new color.
        test.material.color = newColor;
    }
}