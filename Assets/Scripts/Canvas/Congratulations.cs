using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Congratulations : MonoBehaviour
{
    [Tooltip("������ �� �����")]
    [SerializeField] private AudioSource _music;

    [Tooltip("���������-�������� ���������-������������ �� ������")]
    [SerializeField] private GameObject _congratParticles;


    //�������� ����������� ������-������������
    public IEnumerator ShowCongratText()
    {
        yield return new WaitForSeconds(0.5f);
        _music.volume = 0;
        gameObject.SetActive(true);
        _congratParticles.gameObject.SetActive(true);
    }
}
