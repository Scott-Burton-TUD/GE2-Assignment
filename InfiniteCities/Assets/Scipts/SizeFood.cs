using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeFood : MonoBehaviour
{
    float fish;
    public float Foodsize = 1000.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Fish")
        {
            FishBehavior fishBehavior = other.GetComponent<FishBehavior>();
            if (fishBehavior != null)
            {
                fishBehavior.size += Foodsize;
            }

            Destroy(gameObject);
            
        }
    }
}
