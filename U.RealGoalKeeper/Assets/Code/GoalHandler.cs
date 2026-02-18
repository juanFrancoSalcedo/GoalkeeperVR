using UnityEngine;

public class GoalHandler:MonoBehaviour
{
    [SerializeField] TriggerDetector triggerDetector;
    [SerializeField] ScoreUpdateCaller scoreUpdateCaller;
    private void OnEnable() => triggerDetector.OnTriggerEntered += Enter;

    private void OnDisable() => triggerDetector.OnTriggerEntered -= Enter;

    private void Enter(Transform transform) => scoreUpdateCaller.Call();
}