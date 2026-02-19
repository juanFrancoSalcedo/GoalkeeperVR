using TMPro;
using UnityEngine;


[RequireComponent(typeof(TMP_Text))]
public class ScoreTextHandler : MonoBehaviour
{
    [SerializeField] [TextArea(1,2)] private string label = "PUNTAJE:\n@";
    [SerializeField] bool readOnEnable;
    TMP_Text text;

    private void OnEnable()
    {
        ScoreManager.Instance.OnScoreUpdated += UpdateText;

        if (readOnEnable)
            UpdateText(ScoreManager.Instance.Score);
    }

    private void OnDisable()
    {
        if(ScoreManager.Instance)
            ScoreManager.Instance.OnScoreUpdated -= UpdateText;
    }

    void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    public void UpdateText(int score) 
    {
        text.text = label.Replace("@",score.ToString());
    }
}
