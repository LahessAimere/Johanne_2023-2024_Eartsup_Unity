using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class HealthBar : MonoBehaviour
{ 
    private CharacterBehavior _characterBehavior;
    [SerializeField] private ScriptableEventInt _scriptableEventInt;
    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
      //  _characterBehavior.HeathlChanged += ChangedHealthBar;
      _scriptableEventInt.Event += ChangedHealthBar;
    }

    public void OnCharacterEnabled()
    {
        Debug.Log("onCharacterEnabled");
    }

    private void ChangedHealthBar(int newHealthValue)
    {
        _image.fillAmount = newHealthValue * 0.01f;
    }
}
