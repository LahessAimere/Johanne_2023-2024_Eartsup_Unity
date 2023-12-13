using UnityEngine;
public class UIMenu : MonoBehaviour
{
    private InputActionsSystem _controls;
    private bool allChildrenDisabled = false;
    
    private void OnEnable()
    {
        _controls.UI.Enable();
        _controls.Gameplay.Disable();
    }

    private void OnDisable()
    {
        _controls.UI.Disable();
        _controls.Gameplay.Enable();
    }

    private void Awake()
    {
        _controls = new InputActionsSystem();
    }
    
    private void MenuActivate()
    {
        if (allChildrenDisabled)
        {
            Transform firstChild = transform.GetChild(0);
            if (firstChild != null)
            {
                firstChild.gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
        }
        allChildrenDisabled = !allChildrenDisabled;
        
        if (!allChildrenDisabled)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }
}