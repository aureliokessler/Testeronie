using UnityEngine;

public class KeyItem : MonoBehaviour, IInteractable
{
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = FindFirstObjectByType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _gameManager.SetActionText("Press E to drag the Key.");
            GameManager.ActionGameObject = gameObject.GetComponent<IInteractable>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameManager.ActionGameObject = null;
    }

    public bool Run()
    {
        Inventory.Element.Add(InventoryType.Key);
        _gameManager.SetActionText("You have drag this key, he is yours!");
        GameManager.ActionGameObject = null;
        Destroy(gameObject);
        return true;
    }
}