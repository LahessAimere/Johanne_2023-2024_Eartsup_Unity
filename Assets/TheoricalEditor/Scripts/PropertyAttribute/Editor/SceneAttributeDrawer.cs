using System;
using System.IO;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(SceneAttribute))]
public class SceneAttributeDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        string[] sceneNameArray = Array.ConvertAll(EditorBuildSettings.scenes, (EditorBuildSettingsScene scene) =>
        {
            return Path.GetFileNameWithoutExtension(scene.path);
        });

        if (property.propertyType == SerializedPropertyType.Integer)
        {
            using (new EditorGUI.PropertyScope(position, label, property))
            {
                property.intValue = EditorGUI.Popup(position, label.text, property.intValue, sceneNameArray);
            }
        }
        else if (property.propertyType == SerializedPropertyType.String)
        {
            using (new EditorGUI.PropertyScope(position, label, property))
            {
                int sceneIndex = Array.IndexOf(sceneNameArray, property.stringValue);
                sceneIndex = EditorGUI.Popup(position, label.text, sceneIndex, sceneNameArray);
                property.stringValue = sceneNameArray[sceneIndex];
            }
        }
        else
        {
            using (new EditorGUI.PropertyScope(position, label, property))
            {
                GUI.color = Color.red;
                EditorGUI.LabelField(position, "Error : Unvailable property type.");
            }
        }
    }
}
