using Meta.WitAi.CallbackHandlers;
using Oculus.Interaction;
using UnityEngine;

public class GoalHandler:MonoBehaviour
{
    [SerializeField] TriggerDetector triggerDetector;
    [SerializeField] ScoreUpdateCaller scoreUpdateCaller;
    private void OnEnable() => triggerDetector.OnTriggerEntered += Enter;

    private void OnDisable() => triggerDetector.OnTriggerEntered -= Enter;

    private void Enter(Transform _transform)
    {
        if (_transform.TryGetComponent<BallVR>(out var compo))
        {
            if (!compo.HasGoal)
            { 
                scoreUpdateCaller.Call();
                TextVFXMediator.Instance.Publish(TypeTextVFX.Goal);
                compo.HasGoal = true;
            }
        }
    }
}