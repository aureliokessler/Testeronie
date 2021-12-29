using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float jumpHeight = 2f;

    private Vector3 _currentVelocity;
    private bool _isGround;
    
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        var jumpValue = _isGround ? Input.GetAxis("Jump") * jumpHeight : 0f;
        _currentVelocity = new Vector3(Input.GetAxis("Horizontal"), jumpValue, Input.GetAxis("Vertical"));
    }

    private void FixedUpdate() => _rb.MovePosition(_rb.position + _currentVelocity * (movementSpeed * Time.fixedDeltaTime));

    private void OnCollisionEnter(Collision other) => _isGround = true;
    private void OnCollisionExit(Collision other) => _isGround = false;
}
