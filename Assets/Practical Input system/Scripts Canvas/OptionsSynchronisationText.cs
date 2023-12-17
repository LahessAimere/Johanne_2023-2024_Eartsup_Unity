using System;
using UnityEngine;
using UnityEngine.UI;

public class OptionsSynchronisationText : MonoBehaviour
{
    [SerializeField] private Toggle _toggle;
    [SerializeField] private Text _statusText;
    
    private InputActionsSystem _controls;
    
    private void OnEnable()
    {
        _controls.UI.ToggleActivate.Enable();
    }

    private void OnDisable()
    {
        _controls.UI.ToggleActivate.Disable();
    }

    private void Awake()
    {
        _controls = new InputActionsSystem();
        _controls.UI.ToggleActivate.performed += ctx => OnToggleActivate();
    }

    private void OnToggleActivate()
    {
        if (_toggle != null && _statusText != null)
        {
            if (_toggle.isOn)
            {
                _statusText.text = "Disable";
            }
            else
            {
                _statusText.text = "Enable";
            }
        }
    }
}