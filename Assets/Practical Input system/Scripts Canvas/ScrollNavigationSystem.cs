using UnityEngine;
using UnityEngine.EventSystems;

public class ScrollNavigationSystem : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransformContent;
    private InputActionsSystem _controls;
    private GameObject _selectedObject;
    private float _scrollSpeed = 100f;

    private void OnEnable()
    {
        _controls.UI.Navigation.Enable();
    }
    private void OnDisable()
    {
        _controls.UI.Navigation.Disable();
    }

    private void Awake()
    {
        _controls = new InputActionsSystem();
        _controls.UI.Navigation.performed += ct => OnNavigation();
    }

    private void OnNavigation()
    {
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