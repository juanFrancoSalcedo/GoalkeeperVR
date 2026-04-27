using System;
using UnityEngine;

public class AlleyHandler : MonoBehaviour
{
    [SerializeField] private TriggerDetector triggerDetector;
    [SerializeField] private Transform textWellTransform;
    [SerializeField] private ScoreUpdateCaller callerScore;
    [SerializeField] private bool isAwasome = false;
    private bool canPassScore = false;
    private void OnEnable()
    {
        triggerDetector.OnTriggerEntered += OnEnter;
        GameEventBus.Subscribe(StateGameType.Start, ()=> canPassScore=true);
    }

    private void OnDisable()
    {
        if(triggerDetector)
            triggerDetector.OnTriggerEntered -= OnEnter;

        GameEventBus.Subscribe(StateGameType.Start, () => canPassScore = true);
    }

    private void OnEnter(Transform transform)
    {
        if (canPassScore)
        { 
            callerScore.Call();
            TextVFXMediator.Instance.Publish(isAwasome?TypeTextVFX.PassAwasome: TypeTextVFX.Pass, textWellTransform.position, textWellTransform.rotation);
        }
        Invoke(nameof(Disable),1.1f);
    }

    private void Disable() => gameObject.SetActive(false);
}