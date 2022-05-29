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


        /*if (_distance < 15) 
            transform.LookAt(_positionOfPlayer); // ����� ��� ������� ������ � ������ LookAt �������� 1 ��� �� ������� ����
        */

    }


    private void Update()
    {
        _distance = Vector3.Distance(_positionOfCamera.position, transform.position);

        if (_distance > 15)
        {
            transform.LookAt(_positionOfCamera);
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
