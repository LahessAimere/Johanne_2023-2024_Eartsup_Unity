using UnityEngine;
using UnityEngine.InputSystem;


public class CharacterBehavior : MonoBehaviour
{
    private int _health = 100; 
    [SerializeField] private ScriptableEventInt healthChangedEventInt;

    private int Health
    {
        get => _health;
        set
        {
            _health = value;
            healthChangedEventInt.Event?.Invoke(_health);
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
        healthChangedEventInt.Event.Invoke(_health);
    }
}
