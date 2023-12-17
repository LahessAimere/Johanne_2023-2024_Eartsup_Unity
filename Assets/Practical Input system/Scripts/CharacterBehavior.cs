using System;
using UnityEngine;

public class CharacterBehavior : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float rotationSpeed = 5f;
    
    private InputActionsSystem _controls;
    private Vector2 _moveInput;
    private float _rotationInput;
    private bool _isMenuOpen = true;
    

    private void OnEnable()
    {
        _controls.Gameplay.Enable();
        _controls.UI.Disable();
    }

    private void OnDisable()
    {
        _controls.Gameplay.Disable();
        _controls.UI.Enable();
    }

    private void Awake()
    {
        _controls = new InputActionsSystem();

        _controls.Gameplay.Move.performed += ctx => Move();
        _controls.Gameplay.Shoot.performed += ctx => Shoot();
        _controls.Gameplay.OpenMenu.performed += ctx => Menu();
    }

    private void Start()
    {
        _controls.Gameplay.Move.Disable();
        _controls.Gameplay.Shoot.Disable();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _moveInput = _controls.Gameplay.Move.ReadValue<Vector2>();
        Vector3 moveDirection = new Vector3(_moveInput.x, _moveInput.y, 0f).normalized;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
        
        if (_moveInput.magnitude > 0.1f)
        {
            transform.up = Vector3.Lerp(transform.up, moveDirection, rotationSpeed * Time.deltaTime);
        }
    }

    private void Shoot()
    { 
        Instantiate(_bulletPrefab, transform.position, transform.rotation);
    }
    
    private void Menu()
    {
        _isMenuOpen = !_isMenuOpen;

        if (_isMenuOpen)
        {
            _menu.gameObject.SetActive(true);
            _controls.Gameplay.Move.Disable();
            _controls.Gameplay.Shoot.Disable();
        }
        else
        {
            _menu.gameObject.SetActive(false);
            _controls.Gameplay.Move.Enable();
            _controls.Gameplay.Shoot.Enable();
        }
    }
}