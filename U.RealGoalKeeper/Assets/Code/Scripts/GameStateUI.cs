using System;
using UnityEngine;

public class GameStateUI : MonoBehaviour
{
    [SerializeField] private GameObject Container;
    [SerializeField] private GameObject PanelWin;
    [SerializeField] private GameObject PanelLose;
    public void ShowWin()
    {
        Container.SetActive(true);
        //PanelWin.SetActive(true);
    }

    public void ShowLose()
    {
        Container.SetActive(true);
        //PanelLose.SetActive(true);
    }
}
