using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawnAndLoad : MonoBehaviour
{
    [Tooltip("Контейнер-родитель точек спавна")]
    [SerializeField] private Transform _spawnSpotsPath;

    private GameObject _containerForControl; //Необходимо для управления объектом, его спавном, удалением и т.д.
    private GameObject[] _loadedLettersOrDigits;
    private int _countSpawnedObjects = 0;
    private int _countSpawners = 0;
    private Transform[] _spawnSpots;

    //Для выполнения корутин после победы
    [Tooltip("Congratulations GameObject")]
    [SerializeField] private GameObject _congratObj;
    private Congratulations _myCongratulations;

    [Tooltip("WinLevel GameObject")]
    [SerializeField] private GameObject _winPanelObj;
    private WinningPanel _myWinPanel;


    private void Start()
    {
        _myCongratulations = _congratObj.GetComponent<Congratulations>();
        _myWinPanel = _winPanelObj.GetComponent<WinningPanel>(); 

        LoadChoosenMode(PlayerPrefs.GetString("Language"), PlayerPrefs.GetString("Mode"));
        SpawnLetters();
    }

    //Спавнер букв/цифр. По завершении открываем WinningPanel.
    public void SpawnLetters()
    {

        _spawnSpots = new Transform[_spawnSpotsPath.childCount]; // создаем Arr из позиций точек спавна в SpawnSpots

        for (int i = 0; i < _spawnSpotsPath.childCount; i++)
        {
            _spawnSpots[i] = _spawnSpotsPath.GetChild(i);
        }


        if (_countSpawnedObjects < _loadedLettersOrDigits.Length)
        {
            int RandomCountSpawners = Random.Range(0, _spawnSpotsPath.childCount - 1);

            _containerForControl = Instantiate(_loadedLettersOrDigits[_countSpawnedObjects]); // спавнит первый объект
            _countSpawnedObjects += 1;

            _containerForControl.transform.position = _spawnSpots[_countSpawners].position; // Присвоить координаты точки спавна      

            //Чтобы не спавнились дважды на одной позиции
            if (_countSpawners != RandomCountSpawners)
            {
                _countSpawners = RandomCountSpawners;
            }
            else
            {
                _countSpawners += 1;
                while (_countSpawners == RandomCountSpawners)
                {
                    RandomCountSpawners = Random.Range(0, _spawnSpotsPath.childCount - 1);
                    _countSpawners = RandomCountSpawners;
                }
            }
        } else
        {
            StartCoroutine(_myCongratulations.ShowCongratText());
            StartCoroutine(_myWinPanel.OpenWinPanel());
        }
    }

    //Загрузка GameObj из Resource в зависимости от языка и мода.
    private void LoadChoosenMode(string language, string mode)
    {
        if (mode == "Digits")
        {
            _loadedLettersOrDigits = Resources.LoadAll<GameObject>($"Digits/Digits/{language}");
            SelectionSortDigits(_loadedLettersOrDigits);           
        }
        else
        {
            _loadedLettersOrDigits = Resources.LoadAll<GameObject>($"Letters/{language}");
        }       
    }

    // Алгоритм сортировки выбором для string-имен всех загруженных Digits (GameObj) из Resource
    private void SelectionSortDigits(GameObject[] loadedDigits)
    {
        int min;
        GameObject temp;

        for (int i = 0; i < loadedDigits.Length; i++)
        {
            min = i;

            for (int j = i + 1; j < loadedDigits.Length; j++)
            {
                if (int.Parse(loadedDigits[j].name) < int.Parse(loadedDigits[min].name))
                {
                    min = j;
                }
            }

            if (min != i)
            {
                temp = loadedDigits[i];
                loadedDigits[i] = loadedDigits[min];
                loadedDigits[min] = temp;
            }
        }
    }

    /*private void CreateArrOfSounds()
    {
        for (int i = 0; i < _loadedLettersOrDigits.Length; i++)
        {
            _soundsOfloadedObj[i] = _loadedLettersOrDigits[i].GetComponent<AudioSource>();
            _soundsOfloadedObj[i].Play();
        }
    }*/


    //Чит на ПКМ на победу для теста
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            StartCoroutine(_myCongratulations.ShowCongratText());
            StartCoroutine(_myWinPanel.OpenWinPanel());
            //_testSound.Play();
        }
    }
}
