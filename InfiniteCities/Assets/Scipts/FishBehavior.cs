using UnityEngine;

public class FishBehavior : MonoBehaviour
{
    public string targetTag;
    public float speed;
    public float damping;
    public float size = 1;

    void FixedUpdate()
    {
        // Find the nearest object with the target tag
        GameObject[] targets = GameObject.FindGameObjectsWithTag(targetTag);
        GameObject nearestTarget = null;
        float nearestDistance = Mathf.Infinity;
        transform.localScale = new Vector3(size, size, size);
        foreach (GameObject target in targets)
        {
            float distance = Vector3.Distance(transform.position, target.transform.position);
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestTarget = target;
            }
        }

        // Apply force towards the nearest target
        if (nearestTarget != null)
        {
            Vector3 direction = nearestTarget.transform.position - transform.position;
            direction.Normalize();
            GetComponent<Rigidbody>().AddForce(direction * speed * Time.deltaTime);
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, damping * Time.deltaTime);
        }
    }
}