using System;
using TMPro;
using UnityEngine;


[RequireComponent(typeof(TMP_Text))]
public class TimerDisplayer : MonoBehaviour
{
    [SerializeField] Timer timer;
    TMP_Text text;

    private void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        timer.OnUpdateTime += UpdateTime;
    }


    private void OnDisable()
    {
        timer.OnUpdateTime -= UpdateTime;
    }
        
    private void UpdateTime(string obj)
    {
        text.text = obj;
    }

}
