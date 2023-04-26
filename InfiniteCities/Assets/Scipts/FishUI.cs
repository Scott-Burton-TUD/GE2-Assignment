using UnityEngine;

public class FishUI : MonoBehaviour
{
    public TextMesh textMesh; 

    public void Update()
    {
        float UISize = gameObject.GetComponentInParent<FishBehavior>().size;
        float UISpeed = gameObject.GetComponentInParent<FishBehavior>().speed;
        textMesh.text = "Size: " + UISize + " Speed: " + UISpeed;
      }
}