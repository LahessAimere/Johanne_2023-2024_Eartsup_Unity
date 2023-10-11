using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "new" + nameof(ScriptableEventInt), menuName = "Events/Scriptable Object")]
public class ScriptableEventInt : ScriptableObject
{
    public Action<int> Event;

    /*public void RegisterListener(Action action)
    {
        Event += action;
    }

    public void Test()
    {
        Event += () => Debug.Log("Test");
        RegisterListener(Test);
    }*/
}
