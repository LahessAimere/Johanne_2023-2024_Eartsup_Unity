using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class ColliderEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent unityEvent;
    private CharacterBehavior _characterBehavior;
    public void OnTriggerEnter(Collider other)
    {
        unityEvent?.Invoke();
        Debug.Log("");
    }
}
