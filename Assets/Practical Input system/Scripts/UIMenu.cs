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
            //Time.timeScale = 1.0f;
            Transform firstChild = transform.GetChild(0);
            if (firstChild != null)
            {
                firstChild.gameObject.SetActive(true);
            }
        }
        else
        {
            //Time.timeScale = 0.0f;
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
        }
        allChildrenDisabled = !allChildrenDisabled;
    }
}