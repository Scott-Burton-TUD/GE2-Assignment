using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eating : MonoBehaviour
{
    public string fishEatTag;
    // Start is called before the first frame update
    void Update()
    {



    }
    public void OnTriggerEnter(Collider other)
    {
        // Get the game object that owns the collider
        GameObject otherObject = other.gameObject;

        // Check if the game object is a child of the same parent as FishCollider
        //if (otherObject.transform.parent == FishCollider.transform.parent)
        //{
        // Ignore the collision
        //     return;
        // }

        if (otherObject.CompareTag(fishEatTag))
        {
            // Destroy the other game object
            Destroy(otherObject);
            Debug.Log("FUCK U");


        }
    }
   
}
