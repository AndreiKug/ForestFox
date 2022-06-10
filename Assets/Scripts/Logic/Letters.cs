using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letters : MonoBehaviour
{
    private SpawnAndLoad _mySpawn;

    private AudioSource _sound;
    private BoxCollider _collider;
    private MeshRenderer _mesh;

    private void Start()
    {
        GameObject spawnClass = GameObject.Find("ScriptHandler");
        _mySpawn = spawnClass.GetComponent<SpawnAndLoad>();

        _sound = gameObject.GetComponent<AudioSource>();
        _collider = gameObject.GetComponent<BoxCollider>();
        _mesh = gameObject.GetComponent<MeshRenderer>();

    }

    //Т.к. удаленный объект не может воспроизвести звук, сначала скрываем и воспроизводим звук, и через 1f sec удаляем
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _sound.Play();
            _collider.enabled = false;
            _mesh.enabled = false;
            Destroy(gameObject, 1f);

            _mySpawn.SpawnLetters();

        }
    }
}
