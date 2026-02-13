using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallVR : MonoBehaviour
{
    [SerializeField] private float speedMin = 10f;
    [SerializeField] private float speedMax = 10f;
    [SerializeField, Range(0f, 90f)] private float launchAngle = 45f; // degrees above horizontal
    [SerializeField] private bool useImpulse = true; // if true, use Impulse so mass matters; otherwise use VelocityChange

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    public void Shot()
    {
        float angleRad = launchAngle * Mathf.Deg2Rad;
        var speed = Random.Range(speedMin, speedMax);
        // Horizontal direction based on forward but flattened to the XZ plane
        Vector3 forward = transform.forward;
        Vector3 horizontalDir = Vector3.ProjectOnPlane(forward, Vector3.up);

        if (horizontalDir.sqrMagnitude < 1e-6f)
        {
            horizontalDir = transform.forward;
            horizontalDir.y = 0f;
            horizontalDir.Normalize();
        }
        else
        {
            horizontalDir.Normalize();
        }

        Vector3 initialVelocity = horizontalDir * (speed * Mathf.Cos(angleRad)) + Vector3.up * (speed * Mathf.Sin(angleRad));

        if (useImpulse)
        {
            // To get the intended delta-v while respecting mass, apply impulse = deltaV * mass
            Vector3 impulse = initialVelocity * rb.mass;
            rb.AddForce(impulse, ForceMode.Impulse);
        }
        else
        {
            // Directly set velocity change (ignores mass)
            rb.AddForce(initialVelocity, ForceMode.VelocityChange);
        }
    }

    public void SetTransform(Transform _newTransform) 
    {
        print(_newTransform.name);
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = rb.linearVelocity = Vector3.zero;
        rb.position = _newTransform.position;
        rb.rotation = _newTransform.rotation;
        //transform.SetPositionAndRotation(_newTransform.position,_newTransform.rotation);
    }

    void Update()
    {
        // No continuous force applied; physics (gravity) will make the trajectory parabolic
    }
}
