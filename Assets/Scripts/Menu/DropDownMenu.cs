using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DropDownMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text _startButton;
    [SerializeField] private TMP_Text _exitButton;
    [SerializeField] private Text _audioSlider;
    [SerializeField] private Text _musicSlider;
    [SerializeField] private Text _chooseMode;    
    [SerializeField] private Text _dropDownMenuText;


    private void Start()
    {
        //Т.к. PlayerPrefs.SetString срабатывает только при выборе в DropDown, передаем дефолтное значение, если юзер ничего не выберет.
        PlayerPrefs.SetString("Language", "English");        
    }

    // Локализация. Срабатывает при изменении значения в Choose Lnaguage DropDown
    private void ChangeMenuLanguage (int num)
        {

        // Если не будет помещаться текст на немецком.
        // GameObject ChooseModeTitle = GameObject.Find("ImageForTitleToggle");
        // RectTransform RectOfChooseMode = ChooseModeTitle.GetComponent<RectTransform>();


        switch (num)
            {
                case 0: // English
                    _startButton.text = "START";
                    _exitButton.text = "EXIT";
                    _audioSlider.text = "Audio";
                    _musicSlider.text = "Music";
                    _chooseMode.text = "Choose Mode";                    
                    _dropDownMenuText.text = "Language";

                    PlayerPrefs.SetString("Language", "English");                    

                    break;
                case 1: // Deutsch
                    _startButton.text = "START";
                    _exitButton.text = "AUSGANG";
                    _audioSlider.text = "Audio";
                    _musicSlider.text = "Musik";
                    _chooseMode.text = "Wählen Sie den Modus";                    
                    _dropDownMenuText.text = "Sprache";

                    PlayerPrefs.SetString("Language", "German");

                    // RectOfChooseMode.localPosition = Vector3.left;

                    break;
                case 2: // Russian
                    _startButton.text = "СТАРТ";
                    _exitButton.text = "ВЫХОД";
                    _audioSlider.text = "Звуки";
                    _musicSlider.text = "Музыка";
                    _chooseMode.text = "Выберите режим";                    
                    _dropDownMenuText.text = "Язык";

                    PlayerPrefs.SetString("Language", "Russian");                    

                    break;
                case 3: // Espanol
                    _startButton.text = "COMIENZO";
                    _exitButton.text = "SALIDA";
                    _audioSlider.text = "Audio";
                    _musicSlider.text = "Música";
                    _chooseMode.text = "Elija el modo";                    
                    _dropDownMenuText.text = "Idioma";

                    PlayerPrefs.SetString("Language", "Spanish");

                    break;
                case 4: // French
                    _startButton.text = "DÉMARRER";
                    _exitButton.text = "SORTIR";
                    _audioSlider.text = "l'audio";
                    _musicSlider.text = "Musique";
                    _chooseMode.text = "Choisissez le mode";                    
                    _dropDownMenuText.text = "Langue";

                    PlayerPrefs.SetString("Language", "French");

                    break;
                case 5: // Italian
                    _startButton.text = "INIZIO";
                    _exitButton.text = "USCITA";
                    _audioSlider.text = "Audio";
                    _musicSlider.text = "Musica";
                    _chooseMode.text = "Scegli la modalità";                    
                    _dropDownMenuText.text = "Lingua";

                    PlayerPrefs.SetString("Language", "Italian");

                    break;            


            }


    }
}
