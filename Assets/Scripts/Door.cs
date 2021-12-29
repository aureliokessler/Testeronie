using UnityEngine;


public class Door : MonoBehaviour, IInteractable
{
    private GameManager _gameManager;
    private Animator _animator;

    private static readonly int isOpen = Animator.StringToHash("isOpen");

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _animator = GetComponent<Animator>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _gameManager.SetActionText("Press E to open the door.");
            GameManager.ActionGameObject = gameObject.GetComponent<IInteractable>();
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        GameManager.ActionGameObject = null;
    }

    public bool Run()
    {
        if (Inventory.Element.Remove(InventoryType.Key))

        {
            _animator.SetBool(isOpen, true);
            _gameManager.SetActionText("The will by open for you, pleas wait!");
            GameManager.ActionGameObject = null;
            return true;
        }
        else
        {
            _gameManager.SetActionText("Pleas  get a key to Open this door!");
        }

        return false;
    }
}