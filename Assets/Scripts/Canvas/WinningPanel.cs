using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WinningPanel : MonoBehaviour
{
    [Tooltip("Область вывода всех собранных букв/цифр")]
    [SerializeField] private TMP_Text _winLevelText;

    [Tooltip("Контейнер-родитель партиклов-поздравлений на камере")]
    [SerializeField] private GameObject _congratParticles;
    [SerializeField] private TMP_Text _congratulations;

    private string _language;
    private string _mode;
    private string[] _spawnTextContainer;

    private SoundsCatch _mySoundsCatch;

    private void OnEnable()
    {
        StartCoroutine(SpawnText());
    }

    private void Awake()
    {
        _language = PlayerPrefs.GetString("Language");
        _mode = PlayerPrefs.GetString("Mode");

        GameObject soundsClass = GameObject.Find("ScriptHandler");
        _mySoundsCatch = soundsClass.GetComponent<SoundsCatch>();

        LoadWinningText();
    }

    // Хардкод, т.к. Unity неадекватно сортирует буквы в некоторых алфавитах
    private void LoadWinningText()
    {
        if (_mode == "ABC")
        {
            switch (_language)
            {
                case "English":
                    _spawnTextContainer = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
                    break;
                case "German":
                    _spawnTextContainer = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U",  "V", "W", "X", "Y", "Z", "Ä", "Ö", "Ü", "ẞ"};
                    break;
                case "Russian":
                    _spawnTextContainer = new string[] { "А", "Б", "В", "Г", "Д", "Е", "Ё", "Ж", "З", "И", "Й", "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц", "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я" };
                    break;
                case "Spanish":
                    _spawnTextContainer = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "Ñ", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
                    break;
                case "French":
                    _spawnTextContainer = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
                    break;
                case "Italian":
                    _spawnTextContainer = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
                    break;
            }
        } 
        else
        {
            _spawnTextContainer = new string[] { "0 ", "1 ", "2 ", "3 ", "4 ", "5 ", "6 ", "7 ", "8 ", "9 ", "10 ", "11 ", "12 ", "13 ", "14 ", "15 ", "16 ", "17 ", "18 ", "19 ", "20 ", "21 ", "22 ", "23 ", "24 ", "25 ", "26 ", "27 ", "28 ", "29 ", "30" };
        }
    }

    //Корутина для постепенного появления каждой буквы/цифры, а не сразу всех
    private IEnumerator SpawnText()
    {
        for (int i = 0; i < _spawnTextContainer.Length; i++)
        {
            _winLevelText.text += _spawnTextContainer[i];
            _mySoundsCatch.SoundsFromLetters[i].Play();
            yield return new WaitForSeconds(1f);
        }        
    }

    //Корутина отображения алфавита/цифр
    public IEnumerator OpenWinPanel()
    {
        yield return new WaitForSeconds(4f);
        _congratulations.gameObject.SetActive(false);
        _congratParticles.gameObject.SetActive(false);
        gameObject.SetActive(true);
    }
}
