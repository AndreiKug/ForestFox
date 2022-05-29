using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Localization : MonoBehaviour
{
    [Tooltip("Текст-поздравление")]
    [SerializeField] private TMP_Text _congratulations;

    [Tooltip("Окно Settings в игре")]
    [SerializeField] private Text _audioSliderSettings;
    [SerializeField] private Text _musicSliderSettings;
    [SerializeField] private Text _menuButtonSettings;

    [Tooltip("Окно WinPanel после Conratulations")]
    [SerializeField] private Text _continueBtnWinPanel;
    [SerializeField] private Text _menuBtnWinPanel;

    private string _language;


    private void Start()
    {
        _language = PlayerPrefs.GetString("Language");

        SettingsLanguage();
        CongratulationsLanguage();
        WinPanelLanguage();
    }

    // Congratulations. Текст-поздравление
    private void CongratulationsLanguage()
    {
        switch (_language)
        {
            case "English":
                _congratulations.text = "CONGRATULATIONS";
                break;
            case "German":
                _congratulations.text = "HERZLICHE GLÜCKWÜNSCHE";
                break;
            case "Russian":
                _congratulations.text = "ПОЗДРАВЛЯЕМ";
                break;
            case "Spanish":
                _congratulations.text = "FELICIDADES";
                break;
            case "French":
                _congratulations.text = "TOUTES NOS FÉLICITATIONS";
                break;
            case "Italian":
                _congratulations.text = "CONGRATULAZIONI";
                break;
        }
    }

    // Окно Settings. Текст слайдеров Аудио и Музыка. Кнопка MENU
    private void SettingsLanguage()
    {
        switch (_language)
        {
            case "English":
                _audioSliderSettings.text = "Audio";
                _musicSliderSettings.text = "Music";
                _menuButtonSettings.text = "MENU";
                break;
            case "German":
                _audioSliderSettings.text = "Audio";
                _musicSliderSettings.text = "Musik";
                _menuButtonSettings.text = "SPEISEKARTE";
                _menuButtonSettings.fontSize = 18;
                break;
            case "Russian":
                _audioSliderSettings.text = "Аудио";
                _musicSliderSettings.text = "Музыка";
                _menuButtonSettings.text = "МЕНЮ";
                break;
            case "Spanish":
                _audioSliderSettings.text = "Audio";
                _musicSliderSettings.text = "Música";
                _menuButtonSettings.text = "MENÚ";
                break;
            case "French":
                _audioSliderSettings.text = "l'audio";
                _musicSliderSettings.text = "Musique";
                _menuButtonSettings.text = "MENU";
                break;
            case "Italian":
                _audioSliderSettings.text = "Audio";
                _musicSliderSettings.text = "Musica";
                _menuButtonSettings.text = "MENÙ";
                break;
        }
    }

    //Кнопки MENU и CONTINUE в WinPanel
    private void WinPanelLanguage()
    {
        switch (_language)
        {
            case "English":
                _continueBtnWinPanel.text = "CONTINUE";
                _menuBtnWinPanel.text = "MENU";
                break;
            case "German":
                _continueBtnWinPanel.text = "FORTSETZEN";
                _menuBtnWinPanel.text = "SPEISEKARTE";
                break;
            case "Russian":
                _continueBtnWinPanel.text = "ПРОДОЛЖИТЬ";
                _menuBtnWinPanel.text = "МЕНЮ";
                break;
            case "Spanish":
                _continueBtnWinPanel.text = "SEGUIR";
                _menuBtnWinPanel.text = "MENÚ";
                break;
            case "French":
                _continueBtnWinPanel.text = "CONTINUEZ";
                _menuBtnWinPanel.text = "MENU";
                break;
            case "Italian":
                _continueBtnWinPanel.text = "CONTINUA";
                _menuBtnWinPanel.text = "MENÙ";
                break;
        }
    }



}
