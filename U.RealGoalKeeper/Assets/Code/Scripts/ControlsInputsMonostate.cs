using UnityEngine;
using UnityEngine.Events;

public class ControlsInputsMonostate:MonoBehaviour
{
    //[SerializeField] GameObject sphereLeft;
    //[SerializeField] GameObject sphereRight;
    public static bool anyGrab = false;
    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger) || OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
        {
            anyGrab = true;
        }
        if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger) || OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger))
        {
            anyGrab = false;
        }
    }
}
