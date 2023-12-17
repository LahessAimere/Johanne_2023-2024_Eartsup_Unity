using UnityEngine;
using UnityEngine.EventSystems;

public class ScrollNavigationSystem : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransformContent;
    private GameObject _selectedObject;
    private float _scrollSpeed = 100f;

    private void Update()
    {
        // Récupérez l'objet actuellement sélectionné
        _selectedObject = EventSystem.current.currentSelectedGameObject;
        
        if (_selectedObject != null)
        {
            if (_selectedObject.transform.IsChildOf(_rectTransformContent))
            {
                float targetPositionY = -_selectedObject.transform.localPosition.y;
                
                _rectTransformContent.localPosition = Vector3.Lerp(_rectTransformContent.localPosition, new Vector3(_rectTransformContent.localPosition.x, targetPositionY - 30, _rectTransformContent.localPosition.z), Time.deltaTime * _scrollSpeed);
            }
        }
    }
}