using System;
using UnityEngine;

[CreateAssetMenu(fileName = "new" + nameof(ScriptableEventInt), menuName = "Events/Scriptable Event Int")]
public class ScriptableEventInt : ScriptableObject
{
    public Action<int> Event;
}
