using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueControl : MonoBehaviour
{
    private GameObject bitok;
    private Transform cueTransform;
    
    private void Start()
    {
        cueTransform = GetComponent<Transform>();
        bitok = GameObject.FindWithTag("Bitok");
    }

    private void SetBitokDirection()
    {
        
    }
}
