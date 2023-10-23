using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
public class ScriptableEventListener : MonoBehaviour
{
  //  [FormerlySerializedAs("_scriptableEvent")] [SerializeField] private ScriptableEventInt scriptableEventInt;
    [SerializeField] private UnityEvent _callback;
    
    // Start is called before the first frame update
    void Awake()
    {
       // scriptableEventInt.Event += InvokeEvents();
    }

    private void InvokeEvents()
    {
        _callback?.Invoke();
    }
    
}
