using UnityEngine;

public class CoinController : MonoBehaviour
{
    public GameManager gameManager;
    private void OnCollisionEnter(Collision other)
    {
        gameManager.AddScoreValue(1);
        Destroy(gameObject);
    }
}