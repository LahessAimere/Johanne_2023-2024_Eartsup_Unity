using UnityEngine;
using UnityEngine.EventSystems;

public class ScrollNavigationSystem : MonoBehaviour
{
    private GameObject _selectedObject;
    private RectTransform _rectTransform;
    private float _scrollSpeed = 100f;

    void Update()
    {
        // Récupérez l'objet actuellement sélectionné
        _selectedObject = EventSystem.current.currentSelectedGameObject;
        
        if (_selectedObject != null)
        {
            if (_selectedObject.transform.IsChildOf(_rectTransform))
            {
                float targetPositionY = -_selectedObject.transform.localPosition.y;
                
                _rectTransform.localPosition = Vector3.Lerp(_rectTransform.localPosition, new Vector3(_rectTransform.localPosition.x, targetPositionY - 30, _rectTransform.localPosition.z), Time.deltaTime * _scrollSpeed);
            }
        }
    }
}