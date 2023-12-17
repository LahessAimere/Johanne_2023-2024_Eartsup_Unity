using UnityEngine;
using UnityEngine.Events;
public class ScriptableEventListener : MonoBehaviour
{
    [SerializeField] private ScriptableEvent _scriptableEvent;
    [SerializeField] private UnityEvent _callback;

    private void OnEnable()
    {
        _scriptableEvent.Event += InvokeEvents;
    }

    private void OnDisable()
    {
        _scriptableEvent.Event -= InvokeEvents;
    }

    private void InvokeEvents()
    {
        _callback?.Invoke();
    }
    
}
