using UnityEngine;

public static class TransformExtension
{
    public static void ClearChildren(this Transform transform)
    {
        foreach (Transform child in transform)
        {
            Object.Destroy(child.gameObject);
            child.SetParent(null);
        }
    }
}