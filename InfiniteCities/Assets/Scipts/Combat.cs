using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public bool combatState = false;
    public GameObject combatCollider;
    public string fishFightTag;
    // Start is called before the first frame update
    void Update()
    {
        
        

    }
     void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == fishFightTag)
        {
            
            combatState = true;
        }
       
            
        
    }
    
}
