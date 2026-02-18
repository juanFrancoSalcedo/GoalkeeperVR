using System;
using UnityEngine;

public class AlleyHandler : MonoBehaviour
{
    [SerializeField] private TriggerDetector triggerDetector;
    [SerializeField] private GameObject textWellPrototype;
    [SerializeField] private Transform textWellTransform;
    [SerializeField] private ScoreUpdateCaller callerScore;
    public bool waitingPass;
    private void OnEnable() => triggerDetector.OnTriggerEntered += OnEnter;
    private void OnDisable()
    {
        if(triggerDetector)
            triggerDetector.OnTriggerEntered -= OnEnter;
    }

    private void OnEnter(Transform transform)
    {
        callerScore.Call();
        Instantiate(textWellPrototype, textWellTransform.position, textWellTransform.rotation);
        Invoke(nameof(Disable),1.1f);
    }

    private void Disable() => gameObject.SetActive(false);
}