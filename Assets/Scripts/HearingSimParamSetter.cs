using UnityEngine;
using UnityEngine.Audio;
using UnityEditor;
using System.Collections.Generic;

public class HearingSimParamSetter: MonoBehaviour
{
    public AudioMixer audioMixer; // Reference to your Audio Mixer asset

    public List<string> expParamVisibleList; // Reference to your Audio Mixer asset


    private void Start()
    {

        expParamVisibleList = new List<string>();
        expParamVisibleList = GetExposedParameters(audioMixer);

    }


    private void Update()
    {

        expParamVisibleList = GetExposedParameters(audioMixer);
        Debug.Log(string.Join("\n ", expParamVisibleList));

    }

    private List<string> GetExposedParameters(AudioMixer mixer)
    {
        List<string> exposedParams = new List<string>();

        // Using reflection to access the AudioMixer's ExposedParameters
        var dynMixer = new SerializedObject(mixer);
        var parameters = dynMixer.FindProperty("m_ExposedParameters");

        if (parameters != null && parameters.isArray)
        {
            for (int i = 0; i < parameters.arraySize; i++)
            {
                var param = parameters.GetArrayElementAtIndex(i);
                var nameProp = param.FindPropertyRelative("name");

                if (nameProp != null)
                {

                    float value;
                    bool result = mixer.GetFloat(nameProp.stringValue, out value);
                    if (result)
                    {
            
                        Debug.Log(nameProp.stringValue + ": " + value);

                    }
                    else
                    {
                        Debug.Log("nothing");
                    }


                    exposedParams.Add(nameProp.stringValue + ": " + value);

                }

            }
            
        }


        return exposedParams;
    }




}
