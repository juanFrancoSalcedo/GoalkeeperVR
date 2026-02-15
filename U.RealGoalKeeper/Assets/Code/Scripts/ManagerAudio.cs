using B_Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerAudio : Singleton<ManagerAudio>
{
    public AudioSource[] kick;
    public AudioSource startClaps;
    public AudioSource[] whistels;
    public AudioSource whistelStart;
    public AudioSource whistelEnd;
    public AudioSource musicaInicio;
    public AudioSource musicaGameplay;
    public AudioSource musicaCreditos;
    public void PlayKick() => kick[Random.Range(0,kick.Length)].Play();
    public void PlayStart() => startClaps.Play();
    public void PlayWhistelRandom() => whistels[Random.Range(0, whistels.Length)].Play();
    public void PlayWhistelEnd() => whistelEnd.Play();
    public void PlayWhistelStart() => whistelStart.Play();
    public void PlayMusicGameplay() => musicaGameplay.Play();
    public void PlayMusicCreditos() => musicaCreditos.Play();

    private void Start()
    {
        //if (SceneManager.GetActiveScene().name.Contains("GamScene"))
        //    PlayMusicGameplay();
    }

}


