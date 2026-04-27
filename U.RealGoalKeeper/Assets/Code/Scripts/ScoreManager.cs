using B_Extensions;
using System;
using System.Runtime.CompilerServices;

public class ScoreManager : Singleton<ScoreManager>
{
    public event System.Action<int> OnScoreUpdated;
    public int Score => score;
    private int score = 0;
    public void AddScore(int scoreNew) 
    {
        score+= scoreNew;
        OnScoreUpdated?.Invoke(score);
    }
}
