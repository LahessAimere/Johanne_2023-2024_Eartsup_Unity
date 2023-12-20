using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMenu : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    
    private InputActionsSystem _controls;
    private bool _isMenuOpen = true;

    private void OnEnable()
    {
        _controls.UI.Disable();
        _controls.Gameplay.OpenMenu.performed += Menu;
    }

    private void OnDisable()
    {
        _controls.UI.Enable();
        _controls.Gameplay.OpenMenu.performed -= Menu;
    }

    private void Menu(InputAction.CallbackContext _callbackContext)
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