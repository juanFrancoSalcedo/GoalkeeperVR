using UnityEngine;

public class HandColliderHandler : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] private bool isLeft;

    private void Update()
    {
        if (isLeft)
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger))
            {
                animator.SetBool("Grab",true);
            }
            if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger))
            {
                animator.SetBool("Grab", false);
            }
        }
        else
        {
            if (OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
            {
                animator.SetBool("Grab", true);
            }
            if (OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger))
            {
                animator.SetBool("Grab", false);
            }
        }

    }
}
