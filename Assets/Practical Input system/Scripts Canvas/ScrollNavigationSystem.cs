using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ScrollNavigationSystem : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransformContent;
    
    private InputActionsSystem _controls;
    private GameObject _selectedObject;
    private float _scrollSpeed = 100f;

    private void OnEnable()
    {
        _controls.UI.Navigation.Enable();
        _controls.UI.Navigation.performed += context =>  Update();
    }
    private void OnDisable()
    {
        _controls.UI.Navigation.Disable();
        _controls.UI.Navigation.performed -= context =>  Update();
    }

    private void Update()
    {
        //Navigation
        _selectedObject = EventSystem.current.currentSelectedGameObject;
        
        if (_selectedObject != null)
        {
            if (_selectedObject.transform.IsChildOf(_rectTransformContent))
            {
                float targetPositionY = -_selectedObject.transform.localPosition.y;
                Vector3 rectTransformContentNewLocalPosition = new Vector3(_rectTransformContent.localPosition.x, targetPositionY - 30, _rectTransformContent.localPosition.z);
                
                _rectTransformContent.localPosition = Vector3.Lerp(_rectTransformContent.localPosition, rectTransformContentNewLocalPosition, Time.deltaTime * _scrollSpeed);
            }
        }
    }
}