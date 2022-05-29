using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseMode : MonoBehaviour
{

    // Это черновик CHERNOVICK

    [SerializeField] private Animator _animABC;
    [SerializeField] private Animator _animDigits;

    private bool _isABC = true;
    // private bool _isDigits;


    //private bool _isABC_flag = true;
    // private bool _isDigits_flag = false;

    //private bool alreadyCheckedABC;
    //private bool alreadyCheckedDigits;

    // public GameObject[] spawn_Arr_Digits;
    // public GameObject[] spawn_Arr_Letters;
    // private GameObject spawnContainer;
    // public GameObject[] spawnPlace_Arr;
    // private int countSpawnObjects = 0;

    /*void SpawnMode() //bool isABC
    {

        if (!_isDigits_flag && _isABC_flag)
        {
            while (countSpawnObjects < 3)
            {

                spawnContainer = Instantiate(spawn_Arr_Digits[countSpawnObjects]);
                spawnContainer.transform.position = spawnPlace_Arr[countSpawnObjects].transform.position;
                spawnContainer.transform.rotation = Quaternion.Euler(0, 180, 0);

                countSpawnObjects += 1;

            }
        }

        if (_isDigits_flag && !_isABC_flag)
        {
            while (countSpawnObjects < 3)
            {
                spawnContainer = Instantiate(spawn_Arr_Letters[countSpawnObjects]);
                spawnContainer.transform.position = spawnPlace_Arr[countSpawnObjects].transform.position;
                spawnContainer.transform.rotation = Quaternion.Euler(0, 180, 0);

                countSpawnObjects += 1;
            }   
        }
    }*/


    private void Start()
    {
        
    }


    private void Update()
    {
        
    }

    private ChooseMode()
    {
        if (_isABC)
        {

        }
    }
}
