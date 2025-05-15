using UnityEngine;

public class CoinController : MonoBehaviour
{
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = FindFirstObjectByType<GameManager>();
    }
    private void OnCollisionEnter(Collision other)
    {
        _gameManager.SetActionText("You grapped a coin!");
        _gameManager.AddScoreValue(1);
        Destroy(gameObject);
    }
}