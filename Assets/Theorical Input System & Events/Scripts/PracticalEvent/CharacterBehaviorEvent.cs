using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;


public class CharacterBehaviorEvent : MonoBehaviour
{
    [SerializeField] private ScriptableEventInt _onHealthChangedScriptableEventInt;
    
    private int _health = 100; 
    
    private int Health
    {
        get => _health;
        set
        {
            _health = value;
            _onHealthChangedScriptableEventInt.Event?.Invoke(_health);
        }
    }

    public void Hit()
    {
        Health -= 10;
    }
}
