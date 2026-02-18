using System.Collections;

using UnityEngine;

public class ManagerShots : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private BallVR[] balls;

    float timeNextShot = 8f;

    private void OnEnable() => GameEventBus.Subscribe(StateGameType.End, () => StopAllCoroutines());

    private void OnDisable() => GameEventBus.Unsubscribe(StateGameType.End, () => StopAllCoroutines());

    public void CallStartGame() => StartCoroutine(DoPlay());

    private IEnumerator DoPlay() 
    {
        while (true) 
        {
            var target = points[Random.Range(0,points.Length)].transform;
            var ball = GetRandomBall();
            ball.SetTransform(target.transform);
            yield return new WaitForSecondsRealtime(Random.Range(0,3f));
            ball.Shot();
            yield return new WaitForSecondsRealtime(timeNextShot);

            if(timeNextShot > 5f)
                timeNextShot -= 0.3f;
        }
    }

    private BallVR GetRandomBall() 
    {
        BallVR value = null;

        var attemps = 0;
        while (attemps<5) 
        {
            var i = Random.Range(0, balls.Length);
            if (!balls[i].Shoot)
                value = balls[i];
            attemps++;
        }
        return value;
    }
}
