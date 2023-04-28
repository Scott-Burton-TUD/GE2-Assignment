using UnityEngine;

public class FishUI : MonoBehaviour
{
    public TextMesh textMesh;
    public float UISize;
    public float UISpeed;
        public float Overall;
    public void Update()
    {
         UISize = gameObject.GetComponentInParent<FishBehavior>().size;
         UISpeed = gameObject.GetComponentInParent<FishBehavior>().speed;
         Overall = UISpeed + UISize;
        textMesh.text = "Size: " + UISize + " Speed: " + UISpeed + " Overall: " + Overall;

      }
}