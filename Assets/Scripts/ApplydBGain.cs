using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplydBGain : MonoBehaviour
{
    public float dBGain=0;

    private void OnAudioFilterRead(float[] data, int channels)
    {
        float LinGain = Mathf.Pow(10.0f, dBGain / 20.0f);

        for (int i = 0; i < data.Length; i++)
        {
            // Apply the gain to each sample
            data[i] *= LinGain;
        }
    }


}
