using UnityEngine;
using UnityEngine.Events;

public class ControlsInputsMonostate:MonoBehaviour
{
    public static bool anyGrab = false;
    public static bool anyPunch = false;
    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger) || OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
            anyGrab = true;
        if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger) || OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger))
            anyGrab = false;
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
            anyPunch = true;
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger))
            anyPunch = false;

    }
}
