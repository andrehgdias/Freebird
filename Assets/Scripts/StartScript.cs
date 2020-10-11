using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class StartScript : MonoBehaviour
{
    public GameObject bird;
    public GameObject camera;
    public GameObject effect;
    public GameObject turnE;
    public GameObject turnD;
    public Canvas canvas;

    private Boolean started = false;

    // Start is called before the first frame update
    public void StartButton()
    {
        started = true;
        effect.GetComponent<PostProcessVolume>().enabled = true;
        bird.GetComponent<flight>().enabled = true;
        camera.GetComponent<SmoothCamera>().enabled = true;
        canvas.enabled = false;
    }

    void Update()
    {
        if(started)canvas.GetComponent<AudioSource>().volume -= 0.0005f;
        if (canvas.GetComponent<AudioSource>().volume == 0f) {
            canvas.GetComponent<AudioSource>().enabled = false;
        }
    }

    public void Tracer()
    {

        turnE.GetComponent<TrailRenderer>().emitting = true;
        turnD.GetComponent<TrailRenderer>().emitting = true;
    }

    // Update is called once per frame
    public void Sair()
    {
        Application.Quit();
    }
}
