using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[CustomEditor(typeof(CustomEditorComponent))]
public class CustomEditorComponentEditor : Editor
{
    private SerializedProperty _sampleTextProp;
    private SerializedProperty _sceneIndexProp;
    
    
    void OnEnable()
    {
        _sampleTextProp = serializedObject.FindProperty ("_sampleText");
        _sceneIndexProp = serializedObject.FindProperty ("_sceneIndex");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        string sampleText = _sampleTextProp.stringValue;
        EditorGUILayout.LabelField(sampleText);

        using (new EditorGUILayout.HorizontalScope())
        {
            if (GUILayout.Button("-1"))
            {
                _sceneIndexProp.intValue = _sceneIndexProp.intValue - 1;
                SceneManager.GetSceneByBuildIndex(_sceneIndexProp.intValue);
            }
            if (GUILayout.Button("+1"))
            {
                _sceneIndexProp.intValue = _sceneIndexProp.intValue + 1;
                SceneManager.GetSceneByBuildIndex(_sceneIndexProp.intValue);
            }
        }
        serializedObject.ApplyModifiedProperties();
    }
}