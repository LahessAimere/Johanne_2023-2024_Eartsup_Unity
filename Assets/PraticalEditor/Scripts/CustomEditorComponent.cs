using UnityEngine;

public class CustomEditorComponent : MonoBehaviour
{
    [SerializeField] private Stats _stats;
    [SerializeField] private string _sampleText;
    [SerializeField, Scene] private string _sceneName;
    [SerializeField, Scene] private int _sceneIndex;
}
