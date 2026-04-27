using B_Extensions;
using UnityEngine;

public class ButtonPreviouseTutorialPresentation : BaseButtonAttendant
{
    [SerializeField] TutorialPresentationController controller;
    [SerializeField] int index;

    private void Start()
    {
        buttonComponent.onClick.AddListener(CallPreviouse);
    }

    [ContextMenu("Call Previouse")]
    private void CallPreviouse()
    {
        controller.CallPreviouse(index);
        ManagerAudio.Instance.PlayKick();
    }
}
