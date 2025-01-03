using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleOnVolume: MonoBehaviour
{
    // Initialize Variables
    private AudioSource mySource;
    private Vector3 InitialScale;
    private float VolTemp;

    // Start is called before the first frame update
    void Start()
    {
        mySource = this.GetComponent<AudioSource>();
        InitialScale = this.transform.localScale;

    }

    // Update is called once per frame
    void Update()
    {
        // Value of the volume slider 
        VolTemp = mySource.volume;

        // Scale follows volume slider
        this.transform.localScale = InitialScale*VolTemp;

    }


}
