using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class OptionsSynchronisationText : MonoBehaviour
{
    public Toggle toggle;
    public Text statusText;

    private void Update()
    {
        if (toggle != null && statusText != null)
        {
            if (toggle.isOn)
            {
                statusText.text = "Enable";
            }
            else
            {
                statusText.text = "Disable";
            }
        }
    }
}
