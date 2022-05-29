using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValue : MonoBehaviour
{

    [SerializeField] private Slider _audioSlider;
    [SerializeField] private Slider _musicSlider;

    private void Start()
    {
        // Устанавливаем значения громкости по выбранным в Unity
        PlayerPrefs.SetFloat("AudioVolume", _audioSlider.value);
        PlayerPrefs.SetFloat("MusicVolume", _musicSlider.value);
    }

    // При изменении значений в слайдерах устанавливаем новые значения громкости в PlayerPrefs.
    public void SetSliderValue()
    {
        PlayerPrefs.SetFloat("AudioVolume", _audioSlider.value);       
        PlayerPrefs.SetFloat("MusicVolume", _musicSlider.value);        
    }
}
