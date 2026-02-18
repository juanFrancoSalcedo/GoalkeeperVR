using System.Collections;
using UnityEngine;

public class AlleyManager : MonoBehaviour
{
    [SerializeField] AlleyHandler[] alleys;
    private float timeNextShot =10f;

    public void CallStartGame()
    {
        StartCoroutine(DoPlay());
    }

    private IEnumerator DoPlay()
    {
        while (true)
        {
            var alley = GetAlley();
            alley.gameObject.SetActive(true);
            yield return new WaitForSecondsRealtime(timeNextShot);
            if (timeNextShot > 5f)
                timeNextShot -= 0.3f;
        }
    }

    private AlleyHandler GetAlley()
    {
        return alleys[Random.Range(0,alleys.Length)];
    }
}
