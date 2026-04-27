using UnityEngine;

public class ScoreUpdateCaller :MonoBehaviour
{
    [SerializeField] int score = 30;
    public void Call() 
    {
        ScoreManager.Instance.AddScore(score);
    }
}
     
