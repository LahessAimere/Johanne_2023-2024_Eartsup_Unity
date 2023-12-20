using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 5f;
    
    private InputActionsSystem _controls;
    private Vector2 _moveInput;
    private float _rotationInput;

    private void OnEnable()
    {
        _controls.Gameplay.Enable();
        
        _controls = new InputActionsSystem();
        _controls.Gameplay.Move.performed += Move;
    }

    private void OnDisable()
    {
        _controls.Gameplay.Disable();
        
        _controls = new InputActionsSystem();
        _controls.Gameplay.Move.performed -= Move;
    }

    private void Start()
    {
        _controls.Gameplay.Move.Disable();
        _controls.Gameplay.Shoot.Disable();
    }
    
    private void Move(InputAction.CallbackContext _callbackContext)
    {
        _moveInput = _controls.Gameplay.Move.ReadValue<Vector2>();
        Vector3 moveDirection = new Vector3(_moveInput.x, _moveInput.y, 0f).normalized;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
        
        if (_moveInput.magnitude > 0.1f)
        {
            transform.up = Vector3.Lerp(transform.up, moveDirection, rotationSpeed * Time.deltaTime);
        }
    }
}