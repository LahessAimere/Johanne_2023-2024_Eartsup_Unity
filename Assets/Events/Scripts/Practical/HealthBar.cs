using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class HealthBar : MonoBehaviour
{ 
    [SerializeField] private ScriptableEventInt scriptableEventInt;
    private CharacterBehavior _characterBehavior;
    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
      scriptableEventInt.Event += ChangedHealthBar;
    }

    public void OnCharacterEnabled()
    {
        Debug.Log("onCharacterEnabled");
    }

    private void ChangedHealthBar(int newHealthValue)
    {
        _image.fillAmount = newHealthValue * 0.01f;
    }
}
