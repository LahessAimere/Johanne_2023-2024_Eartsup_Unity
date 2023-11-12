using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ScrollNavigationSystem : MonoBehaviour
{
    private GameObject selectedObject;
    public RectTransform content;
    public float scrollSpeed = 100f;

    void Update()
    {
        // Récupérez l'objet actuellement sélectionné
        selectedObject = EventSystem.current.currentSelectedGameObject;
        
        if (selectedObject != null)
        {
            Debug.Log("Objet sélectionné : " + selectedObject.name);
            
            if (selectedObject.transform.IsChildOf(content))
            {
                float targetPositionY = -selectedObject.transform.localPosition.y;

                
                content.localPosition = Vector3.Lerp(content.localPosition, new Vector3(content.localPosition.x, targetPositionY - 30, content.localPosition.z), Time.deltaTime * scrollSpeed);
            }
        }
    }
}