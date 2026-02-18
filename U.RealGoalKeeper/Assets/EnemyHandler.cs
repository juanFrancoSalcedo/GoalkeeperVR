using System.Collections;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    [SerializeField] private BallVR ball;
    [SerializeField] private Transform shotPos;
    [SerializeField] private GameObject[] frames;

    private void OnEnable()
    {
        GameEventBus.Subscribe(StateGameType.Start,StartShot);
        GameEventBus.Subscribe(StateGameType.End, StopAllCoroutines);


    }
    private void OnDisable()
    {
        GameEventBus.Unsubscribe(StateGameType.Start, StartShot);
        GameEventBus.Unsubscribe(StateGameType.End, StopAllCoroutines);
    }

    private void StartShot()
    {
        StartCoroutine(ShotCoroutine());
    }


    private IEnumerator ShotCoroutine()
    {
        while (true) 
        {
            yield return new WaitForSeconds(6);
            ball.SetTransform(shotPos);
            frames[0].SetActive(true);
            frames[1].SetActive(false);
            yield return new WaitForSeconds(Random.Range(0, 3f));
            ball.Shot();
            frames[0].SetActive(false);
            frames[1].SetActive(true);
        }
    }


    
}