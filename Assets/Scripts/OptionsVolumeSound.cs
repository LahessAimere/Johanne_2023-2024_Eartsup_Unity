using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsVolumeSound : MonoBehaviour
{
   [SerializeField] private AudioSource audioSource;
   [SerializeField] private Slider volumeSlider;
   public float maxVolumePercentage = 0.1f;

   private void Start()
   {
      volumeSlider.value = audioSource.volume;

      
      volumeSlider.onValueChanged.AddListener(OnSliderValueChanged);
   }
   
   void OnSliderValueChanged(float value)
   {
      float clampedVolume = Mathf.Clamp(value, 0f, maxVolumePercentage);
      audioSource.volume = clampedVolume;
   }
}
