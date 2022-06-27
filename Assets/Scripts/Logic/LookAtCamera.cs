using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private Transform _positionOfCamera;
    private Transform _positionOfPlayer;

    private float _distance;

    private void Start()
    {
        enabled = false;
        _positionOfCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        _positionOfPlayer = GameObject.FindGameObjectWithTag("Player").transform;


        if (_distance < 15f)
        { 
            // чтобы при близком спавне к игроку LookAt сработал 1 раз на позицию лисы
            transform.LookAt(new Vector3(_positionOfPlayer.transform.position.x, this.transform.position.y, _positionOfPlayer.transform.position.z));
        }         
    }


    private void Update()
    {
        _distance = Vector3.Distance(_positionOfCamera.position, transform.position);

        if (_distance > 15f)
        {
            transform.LookAt(new Vector3(_positionOfCamera.transform.position.x, this.transform.position.y, _positionOfCamera.transform.position.z));
        }         
    }

    private void OnBecameVisible()
    {
        enabled = true;
    }

    private void OnBecameInvisible()
    {
        enabled = false;
    }
}
