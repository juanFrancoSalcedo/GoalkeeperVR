using System;
using UnityEngine;

public class AlleyHandler : MonoBehaviour
{
    [SerializeField] private TriggerDetector triggerDetector;
    [SerializeField] private GameObject textWell;
    [SerializeField] private ScoreUpdateCaller callerScore;
    private void OnEnable() => triggerDetector.OnTriggerEntered += OnEnter;
    private void OnDisable() => triggerDetector.OnTriggerEntered -= OnEnter;
    private void OnEnter(Transform transform) => callerScore.Call();
}