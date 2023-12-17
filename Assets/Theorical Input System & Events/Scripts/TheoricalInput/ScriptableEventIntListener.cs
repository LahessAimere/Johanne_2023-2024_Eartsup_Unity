using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScriptableEventIntListener : MonoBehaviour
{
    [SerializeField] private ScriptableEventInt _scriptableInt;    
    [SerializeField] private UnityEvent<int> _callback;
    private void OnEnable()
    {
        _scriptableInt.Event += InvokeEvents;
    }

    private void OnDisable()
    {
        _scriptableInt.Event -= InvokeEvents;
    }

    private void InvokeEvents(int intValue)
    {
        _callback?.Invoke(intValue);
    }
}