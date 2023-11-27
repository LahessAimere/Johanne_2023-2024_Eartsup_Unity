using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class ScrollNavigationSystem : MonoBehaviour
{
    private GameObject _selectedObject;
    [FormerlySerializedAs("content")] public RectTransform Content;
    [FormerlySerializedAs("scrollSpeed")] public float ScrollSpeed = 100f;

    void Update()
    {
        // Récupérez l'objet actuellement sélectionné
        _selectedObject = EventSystem.current.currentSelectedGameObject;
        
        if (_selectedObject != null)
        {
            if (_selectedObject.transform.IsChildOf(Content))
            {
                float targetPositionY = -_selectedObject.transform.localPosition.y;
                
                Content.localPosition = Vector3.Lerp(Content.localPosition, new Vector3(Content.localPosition.x, targetPositionY - 30, Content.localPosition.z), Time.deltaTime * ScrollSpeed);
            }
        }
    }
}