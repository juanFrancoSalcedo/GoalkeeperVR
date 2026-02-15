using B_Extensions;
using UnityEngine;

public class ButtonNextTutorialPresentation : BaseButtonAttendant
{
    [SerializeField] TutorialPresentationController controller;
    [SerializeField] int index;

    private void Start()
    {
        buttonComponent.onClick.AddListener(CallNext);
    }

    [ContextMenu("Call Next")]
    private void CallNext() 
    {
        controller.CallNext(index);
        ManagerAudio.Instance.PlayKick();
    }
}
