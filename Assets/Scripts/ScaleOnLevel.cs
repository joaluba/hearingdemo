using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScaleOnLevel : MonoBehaviour
{
    public float timeConstant=0.1f;
    private float smoothingFactor;
    private AudioSource audioSource;
    public float rms;  // Current RMS value of the audio samples
    private float L_rms; // Current level in dB
    public float L_rms_smooth; // Current level in dB
    private List<float[]> ListOfChannelBuffers;

    private float minlevel = -60;
    private float maxlevel = 0;
    private Vector3 InitialScale;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        InitialScale = this.transform.localScale;
        rms=0f;
    }

    private void OnAudioFilterRead(float[] data, int channels)
    {//Function: Compute current level of each audio frame


        // Compute root mean square error:
        float sum = 0f;
        for (int i = 0; i < data.Length; i++)
        {
            sum += data[i] * data[i];
        }
        rms = Mathf.Sqrt(sum / data.Length);


    }


    void Update()
    {// Function: smoothen the level variable and use it to control object size

        // Compute level based on the output of OAFR()
        L_rms = 20f * Mathf.Log10(Mathf.Abs(Mathf.Max(rms, Mathf.Epsilon)));

        // Exponential smoothing factor
        smoothingFactor = 1f - Mathf.Exp(-Time.deltaTime / timeConstant);

        // smoothen level
        L_rms_smooth = (1 - smoothingFactor) * L_rms_smooth + smoothingFactor * L_rms;


        // Normalize level to value between 0 and 1 
        var L_norm = (L_rms_smooth - minlevel) / (maxlevel - minlevel);


        // Scale object using normalized value
        this.transform.localScale = InitialScale * L_norm;


    }


}



