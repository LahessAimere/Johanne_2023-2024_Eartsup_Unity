using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class CharacterBehavior : MonoBehaviour
{
    private int _health = 100;
    [SerializeField] private ScriptableEventInt _healthChangedEventInt;

    private int Health
    {
        get => _health;
        set
        {
            _health = value;
            _healthChangedEventInt.Event?.Invoke(_health);
        }
    }
    
    void Start()
    {
        /*StartCoroutine(LoseHealth());

        IEnumerator LoseHealth()
        {
            while (_health > 0)
            {
                yield return new WaitForSeconds(1);
                Health -= 10;
            }
        }*/


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
