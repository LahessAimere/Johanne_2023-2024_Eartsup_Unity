using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScriptableInputListener : MonoBehaviour
{
    [SerializeField] private ScriptableInput _scriptableInput;    
    [SerializeField] private UnityEvent _callback;
    private void OnEnable()
    {
        _scriptableInput.OnPerformed += InvokeEvents;
    }

    private void OnDisable()
    {
        _scriptableInput.OnPerformed -= InvokeEvents;
    }

    private void InvokeEvents()
    {
        _callback?.Invoke();
    }
}
