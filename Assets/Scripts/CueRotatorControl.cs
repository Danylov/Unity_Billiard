using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CueRotatorControl : MonoBehaviour
{
    private GameObject bitok;
    private Transform cueRotatorTransform;
    private CueControl cueControl; 

    private void Start()
    {
        cueRotatorTransform = GetComponent<Transform>();
        cueControl = GameObject.FindWithTag("CueStick").GetComponent<CueControl>();
        bitok = GameObject.FindWithTag("Bitok");
    }

    private void Update()
    {
        // cueRotatorTransform = bitok.transform;
        cueRotatorTransform.position = new Vector3(bitok.transform.position.x, bitok.transform.position.y, bitok.transform.position.z);
        
        Debug.Log("bitok.transform.position = " + bitok.transform.position); // Отладка
        Debug.Log("transform.position = " + transform.position); // Отладка
        
    }
}
