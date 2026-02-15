using System.Collections;
using UnityEngine;

public class ManagerShots : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private BallVR[] balls;

    float timeNextShot = 10f;


    public void CallStartGame() 
    {
        StartCoroutine(DoPlay());
    }

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
        return balls[Random.Range(0, balls.Length)];
    }

}
