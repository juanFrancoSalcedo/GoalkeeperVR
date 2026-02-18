using TMPro;
using UnityEngine;


[RequireComponent(typeof(TMP_Text))]
public class ScoreTextHandler : MonoBehaviour
{
    [SerializeField] [TextArea(1,2)] private string label = "PUNTAJE:\n@";
    TMP_Text text;

    private void OnEnable()
    {
        ScoreManager.Instance.OnScoreUpdated += UpdateText;
    }

    private void OnDisable()
    {
        if(ScoreManager.Instance!= null)
            ScoreManager.Instance.OnScoreUpdated -= UpdateText;
    }

    void Start()
    {
        text = GetComponent<TMP_Text>();
        UpdateText(1);
    }

    public void UpdateText(int score) 
    {
        text.text = label.Replace("@",score.ToString());
    }
}
