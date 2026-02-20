using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class PracticeManager : MonoBehaviour
{
    [SerializeField] private string label;
    [SerializeField] private TMP_Text text;
    [SerializeField] private EnemyControllerShots managerShot;

    int count =0;

    private void Start()
    {
        text.text = label.Replace("@", "0");
    }

    private void OnEnable()
    {
        managerShot.OnCallShot += ReadShot;
        GameEventBus.Subscribe(StateGameType.Practicing, () => {  
            GetComponent<BaseDoAnimationController>().ActiveAnimation(1);
        });
    }

    private void OnDisable()
    {
        managerShot.OnCallShot -= ReadShot;
        GameEventBus.Unsubscribe(StateGameType.Practicing, () => {
            GetComponent<BaseDoAnimationController>().ActiveAnimation(1);
        });
    }

    private void ReadShot()
    {
        if (count <0)
            return;
        count++;
        text.text = label.Replace("@",count.ToString());
        if (count >= 3)
        { 
            StartCoroutine(ShowTextDisplay());
            count = -100000;
        }

    }

    private IEnumerator ShowTextDisplay() 
    {
        yield return new WaitForSeconds(2f);
        text.text = "El juego empieza en ...";
        yield return new WaitForSeconds(2f);
        text.text = "3";
        yield return new WaitForSeconds(0.9f);
        text.text = "2";
        yield return new WaitForSeconds(0.9f);
        text.text = "1";
        yield return new WaitForSeconds(0.9f);
        text.text = "a jugar";
        GameEventBus.Instance.StartTimer();
        yield return new WaitForSeconds(1f);
        GetComponent<BaseDoAnimationController>().ActiveAnimation(2);
    }
}
