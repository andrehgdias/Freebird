﻿using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class HandleEffect : MonoBehaviour
{
    public PostProcessVolume volume;
    float valorAntigo;

    void Start()
    {
        valorAntigo = volume.weight;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Esfera colidiu!");
            volume.weight = 0.1f;
            valorAntigo -= 0.1f;
        }
    }

    void Update ()
    {
        volume.weight = Mathf.Lerp(volume.weight, valorAntigo, Time.deltaTime * 1.5f);
    }
}