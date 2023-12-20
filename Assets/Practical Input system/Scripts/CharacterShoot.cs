using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterShoot : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    
    private InputActionsSystem _controls;


    private void OnEnable()
    {
        _controls.Gameplay.Enable();
        _controls.Gameplay.Shoot.performed += Shoot;
    }

    private void OnDisable()
    {
        _controls.Gameplay.Disable();
        _controls.Gameplay.Shoot.performed -= Shoot;
    }

    private void Shoot(InputAction.CallbackContext _callbackContext)
    { 
        Instantiate(_bulletPrefab, transform.position, transform.rotation);
    }
}
