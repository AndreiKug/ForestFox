using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Congratulations : MonoBehaviour
{
    [Tooltip("Музыка на сцене")]
    [SerializeField] private AudioSource _music;

    [Tooltip("Контейнер-родитель партиклов-поздравлений на камере")]
    [SerializeField] private GameObject _congratParticles;


    //Корутина отображения текста-поздравления
    public IEnumerator ShowCongratText()
    {
        yield return new WaitForSeconds(0.5f);
        _music.volume = 0;
        gameObject.SetActive(true);
        _congratParticles.gameObject.SetActive(true);
    }
}
