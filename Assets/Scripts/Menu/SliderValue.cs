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
        // ������������� �������� ��������� �� ��������� � Unity
        PlayerPrefs.SetFloat("AudioVolume", _audioSlider.value);
        PlayerPrefs.SetFloat("MusicVolume", _musicSlider.value);
    }

    // ��� ��������� �������� � ��������� ������������� ����� �������� ��������� � PlayerPrefs.
    public void SetSliderValue()
    {
        PlayerPrefs.SetFloat("AudioVolume", _audioSlider.value);       
        PlayerPrefs.SetFloat("MusicVolume", _musicSlider.value);        
    }
}
