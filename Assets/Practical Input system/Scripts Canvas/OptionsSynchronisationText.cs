using UnityEngine;
using UnityEngine.UI;

public class OptionsSynchronisationText : MonoBehaviour
{
    public Toggle Toggle;
    public Text StatusText;
    private InputActionsSystem _controls;

    private void OnEnable()
    {
        _controls.UI.Enable();
    }

    private void OnDisable()
    {
        _controls.UI.Disable();
    }

    private void Awake()
    {
        _controls = new InputActionsSystem();
        _controls.UI.ToggleActivate.performed += ctx => OnTogglePressed();
    }

    private void OnTogglePressed()
    {
        if (Toggle != null && StatusText != null)
        {
            if (!Toggle.isOn)
            {
                StatusText.text = "Enable";
            }
            else
            {
                StatusText.text = "Disable";
            }
        }
    }
}