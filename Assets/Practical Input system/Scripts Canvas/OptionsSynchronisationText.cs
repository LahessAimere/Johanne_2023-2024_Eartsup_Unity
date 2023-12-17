using UnityEngine;
using UnityEngine.UI;

public class OptionsSynchronisationText : MonoBehaviour
{
    private Toggle _toggle;
    private Text _statusText;

    private void Update()
    {
        if (_toggle != null && _statusText != null)
        {
            if (_toggle.isOn)
            {
                _statusText.text = "Enable";
            }
            else
            {
                _statusText.text = "Disable";
            }
        }
    }
}