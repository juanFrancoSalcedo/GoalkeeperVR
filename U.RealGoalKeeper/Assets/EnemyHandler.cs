using System.Collections;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    [SerializeField] private BallVR ball;
    [SerializeField] private Transform shotPos;
    [SerializeField] private GameObject[] frames;
    public bool CanShot => !ball.Shoot;

    // Gizmo settings
    [SerializeField] private Color gizmoColor = Color.yellow;
    [SerializeField] private float gizmoLength = 3f;

    private void OnEnable()
    {
        //GameEventBus.Subscribe(StateGameType.Start,StartShot);
        GameEventBus.Subscribe(StateGameType.End, StopAllCoroutines);
    }
    private void OnDisable()
    {
        //GameEventBus.Unsubscribe(StateGameType.Start, StartShot);
        GameEventBus.Unsubscribe(StateGameType.End, StopAllCoroutines);
    }

    [ContextMenu("Shot")]
    public void StartShot() => StartCoroutine(ShotCoroutine());

    private IEnumerator ShotCoroutine()
    {
        ManagerAudio.Instance.PlayWhistelRandom();
        ball.SetTransform(shotPos);
        frames[0].SetActive(true);
        frames[1].SetActive(false);
        yield return new WaitForSeconds(Random.Range(1f, 2f));
        ball.Shot();
        frames[0].SetActive(false);
        frames[1].SetActive(true);
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }

    // Draw a ray in the editor when this object is selected
    private void OnDrawGizmosSelected()
    {
        if (shotPos == null)
            return;

        Gizmos.color = gizmoColor;
        Gizmos.DrawRay(shotPos.position, shotPos.forward * gizmoLength);
        Gizmos.DrawSphere(shotPos.position, 0.05f);
    }
}