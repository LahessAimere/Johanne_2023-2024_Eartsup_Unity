using UnityEngine;
using UnityEngine.UI;

public class OptionsVolumeSound : MonoBehaviour
{
   [SerializeField] private AudioSource _audioSource;
   [SerializeField] private Slider _volumeSlider;
   private float _maxVolumePercentage = 0.1f;

   private void Start()
   {
      _volumeSlider.value = _audioSource.volume;
      _volumeSlider.onValueChanged.AddListener(OnSliderValueChanged);
   }
   
   void OnSliderValueChanged(float slideCursorValue)
   {
      float clampedVolume = Mathf.Clamp(slideCursorValue, 0f, _maxVolumePercentage);
      
      _audioSource.volume = clampedVolume;
   }
}