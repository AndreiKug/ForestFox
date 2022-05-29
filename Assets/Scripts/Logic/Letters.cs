using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letters : MonoBehaviour
{
    private SpawnAndLoad _mySpawn;

    private void Start()
    {
        GameObject spawnClass = GameObject.Find("ScriptHandler");
        _mySpawn = spawnClass.GetComponent<SpawnAndLoad>();
    }

    public void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.CompareTag("Player"))
        {

            Destroy(gameObject);
            _mySpawn.SpawnLetters();
        }
    }
}
