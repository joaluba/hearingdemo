using UnityEngine;
using UnityEngine.Audio;
using System.IO;
using System.Collections;

public class LoadJsonParams : MonoBehaviour
{
    public AudioMixer mixer; // Assign this in the Unity Inspector
    public string jsonFilePathHL; // Set the path to the JSON file
    public string jsonFilePathHA; // Set the path to the JSON file

    private HearingAidParameters HAParams;
    private HearingLossParameters HLParams;

    void Start()
    {
        string jsonHA = File.ReadAllText(jsonFilePathHA);
        string jsonHL = File.ReadAllText(jsonFilePathHL);

        HAParams = JsonUtility.FromJson<HearingAidParameters>(jsonHA);
        HLParams = JsonUtility.FromJson<HearingLossParameters>(jsonHL);

        ApplyParametersToMixer(HLParams);


    }


    public IEnumerator ApplyParametersSequentially(HearingAidParameters HAParams, HearingLossParameters HLParams)
    {
        // Call the first function and wait for it to complete
        ApplyParametersToMixer(HAParams);
        yield return new WaitForEndOfFrame(); 
        // Call the second function
        ApplyParametersToMixer(HLParams);
    }


    private void ApplyParametersToMixer<T>(T parameters)
    {
        foreach (var field in typeof(T).GetFields())
        {
            string paramName = field.Name;
            float paramValue = (float)field.GetValue(parameters);

            Debug.Log("SETTER? " + paramName);

            if (mixer.HasExposedParameter(paramName))
            {
                mixer.SetFloat(paramName, paramValue);
                Debug.Log($"MY SETTER SCRIPT: Set {paramName} to {paramValue}");
            }
            else
            {
                Debug.LogWarning($"Parameter {paramName} is not exposed in the Audio Mixer.");
            }
        }
    }

}



public static class AudioMixerExtensions
{
    public static bool HasExposedParameter(this AudioMixer mixer, string parameterName)
    {
        float value;
        return mixer.GetFloat(parameterName, out value);
    }
}

public class HearingAidParameters
{
    public float HA3DTI_Handle;
    public float HA3DTI_Limiter_On;
    public float HA3DTI_NoiseBits;
    public float HA3DTI_NoiseBefore_On;
    public float HA3DTI_NoiseAfter_On;
    public float HA3DTI_floaterpolation_On;
    public float HA3DTI_HPF_Cutoff;
    public float HA3DTI_LPF_Cutoff;
    public float HA3DTI_Get_Limiter_Compression;

    public float HA3DTI_Process_LeftOn;
    public float HA3DTI_Process_RightOn;

    public float HA3DTI_AttackRelease_Left;
    public float HA3DTI_AttackRelease_Right;

    public float HA3DTI_Normalization_LeftOn;
    public float HA3DTI_Normalization_RightOn;

    public float HA3DTI_Normalization_DB_Left;
    public float HA3DTI_Normalization_DB_Right;

    public float HA3DTI_Normalization_Get_Left;
    public float HA3DTI_Normalization_Get_Right;

    public float HA3DTI_Compression_Left;
    public float HA3DTI_Compression_Right;

    public float HA3DTI_Tone_Low_Left;
    public float HA3DTI_Tone_Mid_Left;
    public float HA3DTI_Tone_High_Left;
    public float HA3DTI_Tone_Low_Right;
    public float HA3DTI_Tone_Mid_Right;
    public float HA3DTI_Tone_High_Right;

    public float HA3DTI_Volume_Left;
    public float HA3DTI_Volume_Right;

    public float HA3DTI_Gain_Level_0_Band_0_Left;
    public float HA3DTI_Gain_Level_0_Band_1_Left;
    public float HA3DTI_Gain_Level_0_Band_2_Left;
    public float HA3DTI_Gain_Level_0_Band_3_Left;
    public float HA3DTI_Gain_Level_0_Band_4_Left;
    public float HA3DTI_Gain_Level_0_Band_5_Left;
    public float HA3DTI_Gain_Level_0_Band_6_Left;

    public float HA3DTI_Gain_Level_1_Band_0_Left;
    public float HA3DTI_Gain_Level_1_Band_1_Left;
    public float HA3DTI_Gain_Level_1_Band_2_Left;
    public float HA3DTI_Gain_Level_1_Band_3_Left;
    public float HA3DTI_Gain_Level_1_Band_4_Left;
    public float HA3DTI_Gain_Level_1_Band_5_Left;
    public float HA3DTI_Gain_Level_1_Band_6_Left;

    public float HA3DTI_Gain_Level_2_Band_0_Left;
    public float HA3DTI_Gain_Level_2_Band_1_Left;
    public float HA3DTI_Gain_Level_2_Band_2_Left;
    public float HA3DTI_Gain_Level_2_Band_3_Left;
    public float HA3DTI_Gain_Level_2_Band_4_Left;
    public float HA3DTI_Gain_Level_2_Band_5_Left;
    public float HA3DTI_Gain_Level_2_Band_6_Left;

    public float HA3DTI_Gain_Level_0_Band_0_Right;
    public float HA3DTI_Gain_Level_0_Band_1_Right;
    public float HA3DTI_Gain_Level_0_Band_2_Right;
    public float HA3DTI_Gain_Level_0_Band_3_Right;
    public float HA3DTI_Gain_Level_0_Band_4_Right;
    public float HA3DTI_Gain_Level_0_Band_5_Right;
    public float HA3DTI_Gain_Level_0_Band_6_Right;

    public float HA3DTI_Gain_Level_1_Band_0_Right;
    public float HA3DTI_Gain_Level_1_Band_1_Right;
    public float HA3DTI_Gain_Level_1_Band_2_Right;
    public float HA3DTI_Gain_Level_1_Band_3_Right;
    public float HA3DTI_Gain_Level_1_Band_4_Right;
    public float HA3DTI_Gain_Level_1_Band_5_Right;
    public float HA3DTI_Gain_Level_1_Band_6_Right;

    public float HA3DTI_Gain_Level_2_Band_0_Right;
    public float HA3DTI_Gain_Level_2_Band_1_Right;
    public float HA3DTI_Gain_Level_2_Band_2_Right;
    public float HA3DTI_Gain_Level_2_Band_3_Right;
    public float HA3DTI_Gain_Level_2_Band_4_Right;
    public float HA3DTI_Gain_Level_2_Band_5_Right;
    public float HA3DTI_Gain_Level_2_Band_6_Right;

    public float HA3DTI_Threshold_0_Left;
    public float HA3DTI_Threshold_0_Right;

    public float HA3DTI_Threshold_1_Left;
    public float HA3DTI_Threshold_1_Right;
}

public class HearingLossParameters
{
    public float HA3DTI_Threshold_2_Left;
    public float HA3DTI_Threshold_2_Right;

    public float HL3DTI_Process_LeftOn;
    public float HL3DTI_Process_RightOn;

    public float HL3DTI_TA_LeftOn;
    public float HL3DTI_TA_RightOn;

    public float HL3DTI_MBE_LeftOn;
    public float HL3DTI_MBE_RightOn;

    public float HL3DTI_FS_LeftOn;
    public float HL3DTI_FS_RightOn;

    public float HL3DTI_TA_LRSync_On;
    public float HL3DTI_TA_LRSync;

    public float HL3DTI_TA_Band_Left;
    public float HL3DTI_TA_Band_Right;

    public float HL3DTI_TA_Noise_Power_Left;
    public float HL3DTI_TA_Noise_Power_Right;

    public float HL3DTI_TA_Noise_LPF_Left;
    public float HL3DTI_TA_Noise_LPF_Right;

    public float HL3DTI_TA_Autocor0_Get_Left;
    public float HL3DTI_TA_Autocor0_Get_Right;

    public float HL3DTI_TA_Autocor1_Get_Left;
    public float HL3DTI_TA_Autocor1_Get_Right;

    public float HL3DTI_HL_Band_0_Left;
    public float HL3DTI_HL_Band_1_Left;
    public float HL3DTI_HL_Band_2_Left;
    public float HL3DTI_HL_Band_3_Left;
    public float HL3DTI_HL_Band_4_Left;
    public float HL3DTI_HL_Band_5_Left;
    public float HL3DTI_HL_Band_6_Left;
    public float HL3DTI_HL_Band_7_Left;
    public float HL3DTI_HL_Band_8_Left;

    public float HL3DTI_HL_Band_0_Right;
    public float HL3DTI_HL_Band_1_Right;
    public float HL3DTI_HL_Band_2_Right;
    public float HL3DTI_HL_Band_3_Right;
    public float HL3DTI_HL_Band_4_Right;
    public float HL3DTI_HL_Band_5_Right;
    public float HL3DTI_HL_Band_6_Right;
    public float HL3DTI_HL_Band_7_Right;
    public float HL3DTI_HL_Band_8_Right;

    public float HL3DTI_FS_Hz_Up_Left;
    public float HL3DTI_FS_Hz_Up_Right;

    public float HL3DTI_FS_Size_Down_Left;
    public float HL3DTI_FS_Size_Down_Right;

    public float HL3DTI_FS_Hz_Down_Left;
    public float HL3DTI_FS_Hz_Down_Right;

    public float HL3DTI_FS_Size_Up_Left;
    public float HL3DTI_FS_Size_Up_Right;

    public float HL3DTI_HL_FS_Approach_Left;
    public float HL3DTI_HL_FS_Approach_Right;

    public float HL3DTI_HL_MBE_Approach_Left;
    public float HL3DTI_HL_MBE_Approach_Right;

    public float HL3DTI_Calibration;
}
