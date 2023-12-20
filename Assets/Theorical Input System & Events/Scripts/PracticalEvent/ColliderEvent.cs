using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[RequireComponent(typeof(Collider))]
public class ColliderEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent _unityEvent;
    private CharacterMovement _characterMovement;
    public void OnTriggerEnter(Collider other)
    {
        _unityEvent?.Invoke();
        Debug.Log("");
    }
}
