using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class HealthBar : MonoBehaviour
{ 
    private CharacterMovement _characterMovement;
    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void ChangedHealthBar(int newHealthValue)
    {
        _image.fillAmount = newHealthValue * 0.01f;
    }
}
