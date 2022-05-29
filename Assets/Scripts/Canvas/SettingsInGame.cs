using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsInGame : MonoBehaviour
{
    [SerializeField] private Slider _audioSlider;
    [SerializeField] private Slider _musicSlider;

    private void Start()
    {
        //Устанавливаем значение слайдера по значениям из Menu
        _audioSlider.value = PlayerPrefs.GetFloat("AudioVolume");
        _musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");      
    }

    public void SetSliderValue()
    {
        //Передаем в PlayerPrefs новые значения, если будут изменения громкости в игре. Метод присвоен в OnValueChanged слайдеров в Settings.
        PlayerPrefs.SetFloat("AudioVolume", _audioSlider.value);
        PlayerPrefs.SetFloat("MusicVolume", _musicSlider.value);
    }

}
