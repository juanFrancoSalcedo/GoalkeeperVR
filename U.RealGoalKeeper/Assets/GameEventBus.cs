using B_Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventBus : Singleton<GameEventBus>
{
    [SerializeField] private Timer timer;
    [SerializeField] private GameStateUI uiStates;
    ScoreChecker scoreChecker;
    private new void Awake()
    {
        base.Awake();
        scoreChecker = new ScoreChecker(ScoreManager.Instance);
    }
    private void OnEnable() => timer.OnTimeCompleted += CheckEnd;

    private void OnDisable() => timer.OnTimeCompleted -= CheckEnd;

    public void StartTimer()
    {
        timer.StartTimer();
        Publish(StateGameType.Start);
    }

    private void CheckEnd()
    {
        if (scoreChecker.CheckPass())
            uiStates.ShowWin();
        else
            uiStates.ShowLose();
        Publish(StateGameType.End);
    }

    private static readonly IDictionary<StateGameType, UnityEvent>
        Events = new Dictionary<StateGameType, UnityEvent>();

    public static void Subscribe(StateGameType type, UnityAction listener) 
    {
        UnityEvent thisEvent;
        if (Events.TryGetValue(type, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else 
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            Events.Add(type, thisEvent);
        }
    }

    public static void Unsubscribe(StateGameType type, UnityAction listener)
    {
        UnityEvent thisEvent;
        if (Events.TryGetValue(type, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    private static void Publish(StateGameType type) 
    {
        UnityEvent thisEvent;

        if (Events.TryGetValue(type, out thisEvent))
        {
            thisEvent?.Invoke();
        }
    }

}
public enum StateGameType
{
    Start,
    End
}

