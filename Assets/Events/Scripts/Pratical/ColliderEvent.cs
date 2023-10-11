using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class ColliderEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent _unityEvent;
    private CharacterBehavior _characterBehavior;
    public void OnTriggerEnter(Collider other)
    {
        _unityEvent?.Invoke();
        Debug.Log("");
    }
}
