using UnityEngine;

[System.Serializable]
public struct Stats
{
    [Range(0, 100)] public int Health;
    [Range(0, 50)] public int ManaValue;
}
