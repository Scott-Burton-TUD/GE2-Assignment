using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog : MonoBehaviour
{

    public bool inZone;

    private void OnTriggerEnter(Collider other)
    {
        inZone = true;
        if (other.CompareTag("Camera") && inZone == true)
        {
            print("OK");
            RenderSettings.fog = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {

        inZone = false;
        if (other.CompareTag("Camera") && inZone == false)
        {
            
            RenderSettings.fog = false;
        }
        
    }




}
