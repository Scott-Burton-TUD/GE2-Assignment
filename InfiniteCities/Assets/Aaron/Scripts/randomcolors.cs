using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomcolors : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // generate a random color
        Color randomColor = new Color(Random.value, Random.value, Random.value, 1.0f);

        // get the renderer component
        Renderer renderer = GetComponent<Renderer>();

        // set the material color to the random color
        renderer.material.color = randomColor;
    }
}

