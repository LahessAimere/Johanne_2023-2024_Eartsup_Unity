using System;
using UnityEngine;

public class CharacterBehavior : MonoBehaviour
{
    private InputActionsSystem _controls;
    private Vector2 _moveInput;
    private float _rotationInput;
    private bool isMenuOpen = false;
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _bulletPrefab;

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

    private void Move()
    {
        Vector3 move = new Vector3(_moveInput.x, _moveInput.y, 0f);
        transform.Translate(move * Time.deltaTime, Space.World);
    }

    private void Shoot()
    { 
        float bulletSpeed = 10f; 
        Instantiate(_bulletPrefab, transform.position, transform.rotation);
        _bulletPrefab.transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
    }
    
    private void Menu()
    {
        Debug.Log("Menu opened!");
        isMenuOpen = !isMenuOpen;

        if (isMenuOpen)
        {
            OpenMenu();
        }
        else
        {
            CloseMenu();
        }
    }
    
    private void OpenMenu()
    {
        _menu.gameObject.SetActive(true);
        Time.timeScale = 0.0f;
    }

    private void CloseMenu()
    {
        _menu.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }
}