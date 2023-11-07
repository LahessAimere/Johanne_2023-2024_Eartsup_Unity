using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;


public class CharacterBehavior : MonoBehaviour
{
    [SerializeField] private ScriptableEventInt _healthChangedEventInt;
    private int _health = 100; 
    
    private int Health
    {
        get => _health;
        set
        {
            _health = value;
            _healthChangedEventInt.Event?.Invoke(_health);
        }
    }

    public void LoseHealthInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            LoseHealth();
        }
    }

    public void LoseHealth()
    {
        _health -= 10;
        _healthChangedEventInt.Event.Invoke(_health);
    }
}
