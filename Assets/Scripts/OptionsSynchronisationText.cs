using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class OptionsSynchronisationText : MonoBehaviour
{
    [FormerlySerializedAs("toggle")] public Toggle Toggle;
    [FormerlySerializedAs("statusText")] public Text StatusText;

    private void Update()
    {
        if (Toggle != null && StatusText != null)
        {
            if (Toggle.isOn)
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