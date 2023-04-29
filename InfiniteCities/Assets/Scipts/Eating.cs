using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eating : MonoBehaviour
{
    public string fishEatTag;
    public float fight;
    public GameObject Combar;
    public GameObject Stats;

    // Start is called before the first frame update
    void Update()
    {

        fight = Stats.GetComponent<FishUI>().Overall;
    }

     void OnTriggerEnter(Collider other)
    {
        //Debug.Log("colliderWOrks");
        // Get the game object that owns the collider
        GameObject otherObject = other.gameObject;

        // Check if the colliding object has a FishUI component
        FishUI otherFishUI = otherObject.GetComponentInChildren<FishUI>();
        if (otherFishUI == null)
        {
            return;
        }

        float EnemyStrenght = otherFishUI.Overall;

        Debug.Log(EnemyStrenght);
        if (otherObject.CompareTag(fishEatTag) && fight > EnemyStrenght)
        {
            // Destroy the other game object
            Combar.GetComponent<Combat>().combatState = false;
            Destroy(otherObject);
            //Debug.Log("F");
        }
        if(fight == EnemyStrenght)
        {
            Combar.GetComponent<Combat>().combatState = false;
        }
    }
}