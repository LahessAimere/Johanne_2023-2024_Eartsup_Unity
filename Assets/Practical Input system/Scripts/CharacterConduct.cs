using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterConduct : MonoBehaviour
{
    [SerializeField] private InputActionsSystem _controls;
    private Vector2 _moveInput;

    private void OnEnable()
    {
        _controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        _controls.Gameplay.Disable();
    }

    private void Awake()
    {
        _controls = new InputActionsSystem();
        
        _controls.Gameplay.Move.performed += ctx => _moveInput = ctx.ReadValue<Vector2>();
        _controls.Gameplay.Shoot.performed += ctx => Shoot();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 move = new Vector3(_moveInput.x, _moveInput.y, 0f);
        transform.Translate(move * Time.deltaTime, Space.World);
    }

    private void Shoot()
    {
        
    }
}