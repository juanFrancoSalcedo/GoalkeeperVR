using B_Extensions;
using UnityEngine;

public class ButtonStartGameMediator : BaseButtonAttendant
{
    [SerializeField] GameEventBus gameController;
    [SerializeField] EnemyControllerShots shotsManager;
    [SerializeField] AlleyManager alleyManager;
    private void Start() => buttonComponent.onClick.AddListener(StartSession);

    [ContextMenu("Restart")]
    private void StartSession()
    {
        GameEventBus.Publish(StateGameType.Practicing);
        shotsManager.CallStartGame();
        alleyManager.CallStartGame();
        ScoreManager.Instance.ResetScore();
        ManagerAudio.Instance.PlayStart();
    }
}