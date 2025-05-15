using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static IInteractable ActionGameObject;
    public static int Score;

    [Header("Panel's")]
    public GameObject winPanel;
    public GameObject actionPanel;
    public GameObject pauseMenu;
    
    [Header("Text Field's")]
    public TMP_Text scoreText;
    public TMP_Text actionText;
    
    [Header("Option's")]
    public float delay = 5f;

    [SerializeField]
    private int _winningScore;

    private float _timelapse;

    private bool _gameInPause = false;

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

        if (Score >= _winningScore)
        {
            winPanel.SetActive(true);
        }
    }

    public void SetPauseMenu(bool value)
    {
        _gameInPause = value;
        pauseMenu.SetActive(value);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        print("You have click Exit Game!");
#else
        Application.Quit();
#endif
    }
}
