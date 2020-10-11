using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class HandleEffect : MonoBehaviour
{
    public PostProcessVolume volume;
    private float valorAntigo;
    private Boolean increase;
    public GameObject ally;

    void Start()
    {
        valorAntigo = volume.weight;
        increase = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            valorAntigo -= 0.2f;
            increase = true;

            ally.GetComponent<Ally>().qtdBirds += 1;
            ally.SetActive(true);
        }
    }

    void Update ()
    {
        if (increase)
        {
            volume.weight = Mathf.Lerp(volume.weight, volume.weight - 0.0f > 0 ? 0.0f : 1f, Time.deltaTime * 2.5f);
        }
        else if (volume.weight != valorAntigo) volume.weight = Mathf.Lerp(volume.weight, valorAntigo, Time.deltaTime * 1.5f);
     }

    void LateUpdate ()
    {
        Debug.Log("Increase: ");
        Debug.Log(increase);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            increase = false;
        }
    }
}
