using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSliderMenu : MonoBehaviour
{

    [SerializeField] private Slider _audioSlider;

    private void Start()
    {
        _audioSlider.value = PlayerPrefs.GetFloat("AudioVolume");
    }

    
    public void SetAudioSliderValue()
    {
        PlayerPrefs.SetFloat("AudioVolume", _audioSlider.value);
    }
}
