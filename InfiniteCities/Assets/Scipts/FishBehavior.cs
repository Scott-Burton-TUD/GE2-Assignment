using UnityEngine;

public class FishBehavior : MonoBehaviour
{
    public string targetTag;
    public string fishFightTag;
    public float speed;
    public float damping;
    public float size = 1;
    bool CombatStateMode;
    public GameObject FishCollider;

    public void Update()
    {
        CombatStateMode = GetComponentInChildren<Combat>().combatState;
        //Debug.Log("combat" + CombatStateMode);
    }
    void FixedUpdate()
    {
        GameObject target = null;
        transform.localScale = new Vector3(size, size, size);

        if (CombatStateMode)
        {
            // If in combat mode, find the nearest game object with a different tag
            GameObject[] targets = GameObject.FindGameObjectsWithTag(fishFightTag);
            float nearestDistance = Mathf.Infinity;
            foreach (GameObject t in targets)
            {
               
                    float distance = Vector3.Distance(transform.position, t.transform.position);
                    if (distance < nearestDistance)
                    {
                        nearestDistance = distance;
                        target = t;
                    }
                
            }
        }
        if (CombatStateMode == false)
        {
            // If not in combat mode, find the nearest game object with the target tag
            GameObject[] targets = GameObject.FindGameObjectsWithTag(targetTag);
            float nearestDistance = Mathf.Infinity;
            foreach (GameObject t in targets)
            {
                float distance = Vector3.Distance(transform.position, t.transform.position);
                if (distance < nearestDistance)
                {
                    nearestDistance = distance;
                    target = t;
                }
            }
        }

        // Apply force towards the target
        if (target != null)
        {
            Vector3 direction = target.transform.position - transform.position;
            direction.Normalize();
            GetComponent<Rigidbody>().AddForce(direction.normalized * speed);
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, damping * Time.deltaTime);
        }
    }
    
}