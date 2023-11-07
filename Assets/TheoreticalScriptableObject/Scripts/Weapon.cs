using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Datas", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class Weapon : ScriptableObject
{
    private int _DamageValue = 10;

    public int DamageValue;

    private void Awake()
    {
        Debug.Log("Weapon::Awake");
    }

    void Attack()
    {
        
    }   
    private void OnEnable()
    {
        Debug.Log("Weapon::OnEnable");
        _DamageValue += 10;
    }
}