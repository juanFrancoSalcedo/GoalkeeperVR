using B_Extensions;
using System;
using System.Runtime.CompilerServices;

public class ScoreManager : Singleton<ScoreManager>
{
    public event Action<int> OnScoreUpdated;
    public int Score => score;
    private static int score = 0;
    public void AddScore(int scoreNew) 
    {
        score+= scoreNew;
        OnScoreUpdated?.Invoke(score);
    }

    public void ResetScore() 
    {
        score = 0;
        OnScoreUpdated?.Invoke(score);
    }
}
