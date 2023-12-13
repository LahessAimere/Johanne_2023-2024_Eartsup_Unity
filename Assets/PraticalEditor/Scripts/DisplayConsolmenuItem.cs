using UnityEditor;
using UnityEngine;

public class DisplayConsolmenuItem : MonoBehaviour
{
    [MenuItem("Tools/Log Console")]
    static void LogConsole()
    {
        Debug.Log(Selection.activeGameObject.name);
    }

    [MenuItem("Tools/Log Console", true)]
    static bool ValidateLogSelectedActiveGameObject()
    {
        return Selection.activeGameObject != null;
    }
}
