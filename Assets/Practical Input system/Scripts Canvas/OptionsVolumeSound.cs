using UnityEngine;
using UnityEngine.UI;

public class OptionsVolumeSound : MonoBehaviour
{
   //[SerializeField] private AudioSource _audioSource;
   [SerializeField] private Slider _volumeSlider;
   public float MaxVolumePercentage = 0.1f;

   private void Start()
   {
      //_volumeSlider.value = _audioSource.volume;
      _volumeSlider.onValueChanged.AddListener(OnSliderValueChanged);
   }
   
   void OnSliderValueChanged(float value)
   {
      float clampedVolume = Mathf.Clamp(value, 0f, MaxVolumePercentage);
      //_audioSource.volume = clampedVolume;
   }
}