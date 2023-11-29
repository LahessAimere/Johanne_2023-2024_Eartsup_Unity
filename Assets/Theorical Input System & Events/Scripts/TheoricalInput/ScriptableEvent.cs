using System;
using UnityEngine;

[CreateAssetMenu(fileName = "new" + nameof(ScriptableEvent), menuName = "Events/Scriptable Event")]
public class ScriptableEvent : ScriptableObject
{
    public Action Event;
}
