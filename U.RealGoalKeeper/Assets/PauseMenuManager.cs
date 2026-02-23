using B_Extensions.SceneLoader;
using UnityEngine;

public class PauseMenuManager: MonoBehaviour
{
    [SerializeField] GameObject panelPause;

    bool paused = false;
    bool started = false;
    private void OnEnable()
    {
        GameEventBus.Subscribe(StateGameType.Practicing, ()=> started = true);
    }

    private void OnDisable()
    {
        GameEventBus.Unsubscribe(StateGameType.Practicing, () => started = true);
    }

    void Update()
    {
        if (!started)
            return;

        if (OVRInput.GetDown(OVRInput.Button.Start) ||
            OVRInput.GetDown(OVRInput.Button.Two) ||
            OVRInput.GetDown(OVRInput.Button.One))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if (paused)
        {
            paused = false;
            panelPause.SetActive(false);
            SceneLoader.Instance.Pause(false);
        }
        else
        {
            panelPause.SetActive(true);
            SceneLoader.Instance.Pause(true);
            paused = true;
        }
    }
}
