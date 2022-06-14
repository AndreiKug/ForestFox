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
            transform.LookAt(_positionOfPlayer); // чтобы при близком спавне к игроку LookAt сработал 1 раз на позицию лисы
            transform.Rotate(0, 0, 0);
        }
            
    }


    private void Update()
    {
        _distance = Vector3.Distance(_positionOfCamera.position, transform.position);

        if (_distance > 15f)
        {
            transform.LookAt(_positionOfCamera);
        } 
        /*else if (_distance > 10f || _distance < 15f)
        {
            //transform.Rotate(0, 0, 0);
            transform.LookAt(_positionOfPlayer);
        }*/
        
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
