using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseWander : SteeringBehaviour
{
    public float frequency = 0.3f;
    public float radius = 10.0f;

    public float theta = 0;
    public float amplitude = 80;
    public float distance = 5;

    public enum Axis { Horizontal, Vertical, Both };
    public Axis axis = Axis.Both;

    Vector3 target;
    Vector3 worldTarget;

    private void OnDrawGizmos()
    {
        if (Application.isPlaying && isActiveAndEnabled)
        {
            Vector3 localCp = (Vector3.forward * distance);
            Vector3 worldCP = transform.TransformPoint(localCp);
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(worldCP, radius);
            Gizmos.color = Color.magenta;
            Gizmos.DrawLine(transform.position, worldTarget);
        }
    }

    // Update is called once per frame
    public override Vector3 Calculate()
    {
        // Get a random vector for the target
        target = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * radius;

        // Add the distance offset and rotate the target to world space
        Vector3 localtarget = target + Vector3.forward * distance;
        worldTarget = transform.TransformPoint(localtarget);

        return boid.SeekForce(worldTarget);
    }
}