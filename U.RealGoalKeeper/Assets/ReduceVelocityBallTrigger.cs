using System;
using System.Collections;
using UnityEngine;

public class ReduceVelocityBallTrigger : MonoBehaviour
{
    [SerializeField] private TriggerDetector triggerDetector;
    bool hasShoot = false;
    Collider _collider = null;

    private void Awake()
    {
        _collider = triggerDetector.GetComponent<Collider>();
    }


    private void OnEnable()
    {
        triggerDetector.OnTriggerEntered += OnTriggerBall;
        EnemyControllerShots.OnCallShot += ActiveTrigger;
    }


    private void OnDisable()
    {
        triggerDetector.OnTriggerEntered -= OnTriggerBall;
        EnemyControllerShots.OnCallShot -= ActiveTrigger;
    }

    private void OnTriggerBall(Transform transform)
    {
        if (transform.TryGetComponent<BallVR>(out var ball))
        {
            if (!ball.HasGrab)
            { 
                ball.ReduceVelocity();
                _collider.enabled = 
                hasShoot = false;
            }
        }
    }

    private void ActiveTrigger()
    {
        _collider.enabled = 
        hasShoot = true;
    }

    public void CheckPunch(bool isPunchHand)
    {
        if (isPunchHand)
            _collider.enabled = false;
        else
            if (hasShoot)
                _collider.enabled = true;
    }
}
