using System;
using UnityEngine;


[RequireComponent(typeof(ScoreUpdateCaller))]
public class HandColliderHandler : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject collisionPunch;
    [SerializeField] GameObject collisionExtends;
    [SerializeField] private bool isLeft;
    [SerializeField] private Vector3 posGrabColls;
    [SerializeField] private Vector3 posExtendsColls;
    //[SerializeField] private float hitForce = 2f; // fuerza aplicada al chocar
    ScoreUpdateCaller scoreCaller;
    private bool canPassScore;

    private void Start()
    {
        scoreCaller = GetComponent<ScoreUpdateCaller>();
    }

    private void OnEnable()
    {
        if (collisionPunch.TryGetComponent<CollisionDetector>(out var compo)) 
        {
            compo.OnCollisionEntered += CheckCollision;
        }
        GameEventBus.Subscribe(StateGameType.Start, () => canPassScore = true);
    }

    private void OnDisable()
    {
        if (collisionPunch.TryGetComponent<CollisionDetector>(out var compo))
        {
            compo.OnCollisionEntered -= CheckCollision;
        }
        GameEventBus.Unsubscribe(StateGameType.Start, () => canPassScore = true);
    }

    private void CheckCollision(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<BallVR>(out var compo))
        {
            if (!compo.HasHandCollide)
            {
                if (canPassScore)
                { 
                    scoreCaller.Call();
                    TextVFXMediator.Instance.Publish(TypeTextVFX.BallAway);
                }
                ManagerAudio.Instance.PlayCheers();
            }
            compo.HasHandCollide = true;
            compo.AddPunchForce();
        }
    }

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
