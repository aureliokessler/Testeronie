using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static IInteractable ActionGameObject;
    public static int Score;

    public GameObject winPanel;
    public TMP_Text scoreText;
    public float delay = 5f;
    public TMP_Text actionText;
    public GameObject actionPanel;

    public int winningScore;

    private float _timelapse;

    public void SetActionText(string text)
    {
        actionText.text = text;
        actionPanel.SetActive(true);
        _timelapse = 0;
    }

    public void AddScoreValue(int value)
    {
        Score += value;
        scoreText.SetText("Score: " + Score);
    }

    private void Update()
    {
        if (actionPanel.gameObject.activeInHierarchy)
        {
            // Debug.Log(_timelapse);
            _timelapse += Time.deltaTime;
        }
        
        if (_timelapse >= delay)
        {
            actionText.text = "";
            actionPanel.SetActive(false);
            _timelapse = 0;
        }

        if (Score >= winningScore)
        {
            winPanel.SetActive(true);
        }
    }
}
