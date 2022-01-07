using UnityEngine;
using UnityEngine.InputSystem;

public class ControlBindings : MonoBehaviour
{
    [Header("Character Input Values")]
    public Vector2 move;
    public Vector2 look;
    public bool jump;
    public bool sprint;

    [Header("Movement Settings")]
    public bool analogMovement;
    
#if !UNITY_IOS || !UNITY_ANDROID
    [Header("Mouse Cursor Settings")]
    public bool cursorLocked = true;
    public bool cursorInputForLook = true;
#endif

    public void Move(InputValue value)
    {
        move = value.Get<Vector2>();
    }
    
    public void Look(InputValue value)
    {
        if (cursorInputForLook)
        {
            look = value.Get<Vector2>();
        }
    }
    
    public void Jump(InputValue value)
    {
        jump = value.isPressed;
    }
    
    public void Sprint(InputValue value)
    {
        sprint = value.isPressed;
    }
    
#if !UNITY_IOS || !UNITY_ANDROID
    private void OnApplicationFocus(bool hasFocus)
    {
        SetCursorState(cursorLocked);
    }

    private void SetCursorState(bool newState)
    {
        Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
    }
#endif
}
