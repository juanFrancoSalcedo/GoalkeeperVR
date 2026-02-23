using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    [SerializeField] private BallVR ball;
    [SerializeField] private Transform shotPosStationary;
    [SerializeField] private Transform shotPosBondaries;
    [SerializeField] private GameObject[] frames;
    [SerializeField] private List<SpriteRenderer> sprites = new List<SpriteRenderer>();
    [SerializeField] private bool flipX = false;

    // Gizmo settings
    [SerializeField] private float gizmoLength = 3f;

    bool isStationary => BoundaryDetector.CheckBoundaryType() == BoundaryDetector.TypeBoundary.Stationary;
    public bool CanShot => !ball.Shoot;

    private void OnValidate()
    {
        sprites.ForEach(spt => spt.flipX = flipX);
    }

    private void OnEnable()
    {
        sprites.ForEach(spt => spt.flipX = flipX);
        //sprites.ForEach(spt => spt.color = isStationary?Color.blue:Color.red);
        GameEventBus.Subscribe(StateGameType.End, StopAllCoroutines);
    }
    private void OnDisable()
    {

        GameEventBus.Unsubscribe(StateGameType.End, StopAllCoroutines);
    }

    [ContextMenu("Shot")]
    public void StartShot() => StartCoroutine(ShotCoroutine());

    private IEnumerator ShotCoroutine()
    {
        ManagerAudio.Instance.PlayWhistelRandom();
        ball.SetTransform(isStationary?shotPosStationary:shotPosBondaries);
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
        var shotPosType = isStationary ? shotPosStationary : shotPosBondaries;

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(shotPosStationary.position, shotPosStationary.forward * gizmoLength);
        Gizmos.DrawSphere(shotPosStationary.position, 0.05f);

        Gizmos.color = Color.red;
        Gizmos.DrawRay(shotPosBondaries.position, shotPosBondaries.forward * gizmoLength);
        Gizmos.DrawSphere(shotPosBondaries.position, 0.05f);
    }
}