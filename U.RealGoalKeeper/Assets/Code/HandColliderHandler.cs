using UnityEngine;

public class HandColliderHandler : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject collisionPunch;
    [SerializeField] GameObject collisionExtends;
    [SerializeField] private bool isLeft;
    [SerializeField] private Vector3 posGrabColls;
    [SerializeField] private Vector3 posExtendsColls;
    private void Update()
    {
        if (isLeft)
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger))
            {
                animator.SetBool("Grab",true);
                transform.localPosition = posGrabColls;
            }

            if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger))
            { 
                animator.SetBool("Grab", false);
                transform.localPosition = posExtendsColls;
            }

            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            {
                collisionPunch.SetActive(true);
                collisionExtends.SetActive(false);
                animator.SetBool("Punch", true);
            }
            if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
            {
                collisionPunch.SetActive(false);
                collisionExtends.SetActive(true);
                animator.SetBool("Punch", false);
            }
        }
        else
        {
            if (OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
            { 
                animator.SetBool("Grab", true);
                transform.localPosition = posGrabColls;

            }
            if (OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger))
            { 
                animator.SetBool("Grab", false);
                transform.localPosition = posExtendsColls;
            }

            if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
            {
                collisionPunch.SetActive(true);
                collisionExtends.SetActive(false);
                animator.SetBool("Punch", true);
            }
            if (OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger))
            {
                collisionPunch.SetActive(false);
                collisionExtends.SetActive(true);
                animator.SetBool("Punch", false);
            }
        }

    }
}
