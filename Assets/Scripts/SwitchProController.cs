using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchProController : MonoBehaviour
{
    public Camera cam;
    public float speedMovement = 0.1f;
    public float speedJump = 5f;
    public float speedRotation = 0.1f;
    public float maxJumpHeight = 1f;
    
    private float _playerHeight;
    private Vector3 _currentMovementDirection = Vector3.zero;
    // private Vector3 _currentJumpVelocity = Vector3.zero;
    
    private Rigidbody _rb;
    private bool _isGround;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        // player movemend
        _rb.MovePosition( Vector3.Lerp(_rb.position, _rb.position + _currentMovementDirection * speedMovement, Time.fixedTime) );
            
        // player Jump
    }

    private void LateUpdate()
    {
        // player rotation
        var lookAt = new Vector3( cam.transform.forward.x, 0f, cam.transform.forward.z) * speedRotation * Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(lookAt, cam.transform.up);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        _isGround = collision.gameObject.layer == LayerMask.NameToLayer($"Ground");
        if (_isGround)
        {
            _playerHeight = _rb.position.y;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        _isGround = false;
    }

    public void Move(InputAction.CallbackContext context)
    {
        Vector2 readValue = context.ReadValue<Vector2>();
        Vector3 dir = new Vector3(readValue.x, 0f, readValue.y);
        _currentMovementDirection = dir;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        // I want to execute the action once and then the player should be able to jump to a maximum height.
        if (!context.performed) return;
        if (!_isGround) return;
        
        // float readValue = context.ReadValue<float>();
        // Vector3 dir = new Vector3(0f, readValue, 0f);

        // jump height
        var actualMaxJumpHeight = _playerHeight + maxJumpHeight;
            
        _rb.AddForce(Vector3.up * speedJump, ForceMode.Impulse);
    }

    public void Event(InputAction.CallbackContext context) 
    {
        if (context.ReadValueAsButton())
        {
            IInteractable actionGameObject = GameManager.ActionGameObject;
            if(actionGameObject != null && actionGameObject.Run())
                Debug.Log("Run is executed!");
        }
    }
}
