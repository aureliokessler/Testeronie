using TMPro;
using UnityEditor.SearchService;
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

    public void ActivatePauseMenu()
    {
        pauseMenu.SetActive(true);
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
