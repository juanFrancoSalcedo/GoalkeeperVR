using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody))]
public class BallVR : MonoBehaviour
{
    [SerializeField] private ScoreUpdateCaller scoreUpdateCaller;
    [SerializeField] private float speedMin = 10f;
    [SerializeField] private float speedMax = 10f;
    [SerializeField, Range(0f, 90f)] private float launchAngle = 45f;
    [SerializeField] private bool useImpulse = true;
    [SerializeField] private PhysicsMaterial notBouncyMat = null;
    [SerializeField] private PhysicsMaterial bufferBouncyMat = null;
    [SerializeField] private float restoreInteractebleTime = 4f;
    private Rigidbody rb;
    private Collider col;

    public bool Shoot = false;
    public bool HasGoal = false;
    public bool HasHandCollide = false;
    public bool HasGrab = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        col = GetComponent<Collider>();
        transform.SetParent(null);
    }

    public void Shot()
    {
        Shoot = true;
        HasGoal = HasHandCollide= HasGrab = scoreSent = false;
        Invoke(nameof(ResetShoot), restoreInteractebleTime);
        float angleRad = launchAngle * Mathf.Deg2Rad;
        var speed = Random.Range(speedMin, speedMax);
        // Horizontal direction based on forward but flattened to the XZ plane
        Vector3 forward = transform.forward;
        Vector3 horizontalDir = Vector3.ProjectOnPlane(forward, Vector3.up);
        ManagerAudio.Instance.PlayKick();
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
            rb.AddForce(initialVelocity, ForceMode.VelocityChange);
    }

    Coroutine coroutine;
    public void AddPunchForce() 
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }
        else
            StartCoroutine(DoApplyPunch());
    }

    IEnumerator DoApplyPunch() 
    {
        yield return new WaitForSeconds(0.1f);
        rb.linearVelocity *= 2;
        coroutine = null;
    }

    private void ResetShoot() => Shoot = false;

    public void SetTransform(Transform _newTransform)
    { 
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = rb.linearVelocity = Vector3.zero;
        rb.position = _newTransform.position;
        rb.rotation = _newTransform.rotation;
    }

    bool scoreSent;
    public void SendScore() 
    {
        if (!scoreSent)
        {
            scoreSent = true;
            scoreUpdateCaller.Call();
            TextVFXMediator.Instance.Publish(TypeTextVFX.Grab);
        }
    }

    void FixedUpdate() => col.material = ControlsInputsMonostate.anyPunch ? bufferBouncyMat : notBouncyMat;
}
