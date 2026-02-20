using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyControllerShots : MonoBehaviour
{
    [SerializeField] private List<EnemyHandler> enemies = new List<EnemyHandler>();

    float timeNextShot = 6f;
    public event System.Action OnCallShot;
    private void OnEnable() => GameEventBus.Subscribe(StateGameType.End, () => StopAllCoroutines());

    private void OnDisable() => GameEventBus.Unsubscribe(StateGameType.End, () => StopAllCoroutines());

    public void CallStartGame() => StartCoroutine(DoPlay());

    private IEnumerator DoPlay() 
    {
        while (true) 
        {
            EnemyHandler Enemy = GetAvailableEnemy();
            Enemy.gameObject.SetActive(true);
            yield return new WaitForSecondsRealtime(Random.Range(0,3f));
            Enemy.StartShot();
            OnCallShot?.Invoke();
            yield return new WaitForSecondsRealtime(timeNextShot);
            if(timeNextShot > 5f)
                timeNextShot -= 0.3f;
        }
    }

    private EnemyHandler GetAvailableEnemy() 
    {
        List<EnemyHandler> randomList = new List<EnemyHandler>();
        if (randomList.Count == 0)
        { 
            for (int i =0;i <6;i++) 
            {
                EnemyHandler handler = enemies[Random.Range(0, enemies.Count)];
                if (!randomList.Contains(handler))
                    randomList.Add(handler);
            }
        }
        return randomList.Where(e =>e.CanShot).FirstOrDefault();
    }
}
