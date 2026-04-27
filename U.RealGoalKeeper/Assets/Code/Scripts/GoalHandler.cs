using Meta.WitAi.CallbackHandlers;
using Oculus.Interaction;
using UnityEngine;

public class GoalHandler:MonoBehaviour
{
    [SerializeField] TriggerDetector triggerDetector;
    [SerializeField] ScoreUpdateCaller scoreUpdateCaller;
    private bool canPassScore;

    private void OnEnable()
    {
        triggerDetector.OnTriggerEntered += Enter;
        GameEventBus.Subscribe(StateGameType.Start, () => canPassScore = true);
    }

    private void OnDisable()
    {
        triggerDetector.OnTriggerEntered -= Enter;
        GameEventBus.Unsubscribe(StateGameType.Start, () => canPassScore = true);
    }

    private void Enter(Transform _transform)
    {
        if (_transform.TryGetComponent<BallVR>(out var compo))
        {
            if (!compo.HasGoal)
            {
                if (canPassScore)
                { 
                    scoreUpdateCaller.Call();
                    TextVFXMediator.Instance.Publish(TypeTextVFX.Goal);
                }
                compo.HasGoal = true;
            }
        }
    }
}