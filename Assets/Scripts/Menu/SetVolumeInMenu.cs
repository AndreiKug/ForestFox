using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetVolumeInMenu : MonoBehaviour
{
    private AudioSource _music;

    
    private void Start()
    {
        _music = GetComponent<AudioSource>();
        _music.volume = PlayerPrefs.GetFloat("MusicVolume");
    }

    public void SetMusicVolume()
    {
        _music.volume = PlayerPrefs.GetFloat("MusicVolume");
    }
}
