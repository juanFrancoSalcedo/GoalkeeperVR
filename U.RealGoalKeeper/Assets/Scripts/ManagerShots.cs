using System.Collections;
using UnityEngine;

public class ManagerShots : MonoBehaviour
{
    [SerializeField] private Transform[] backs;
    [SerializeField] private BallVR ball;


    private IEnumerator Start() 
    {
        while (true) 
        {
            var target = backs[Random.Range(0,backs.Length)].transform;
            ball.SetTransform(target.transform);
            yield return new WaitForSecondsRealtime(Random.Range(0,3f));
            ball.Shot();
            yield return new WaitForSecondsRealtime(10);
        }
    }


}
