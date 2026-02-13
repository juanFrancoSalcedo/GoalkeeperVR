using UnityEngine;

public class ControlsInputsReader:MonoBehaviour
{
    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            Debug.Log("Trigger pressed (legacy)");
        }

        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            Debug.Log("Trigger pressed (legacy)");
        }

    }
}
