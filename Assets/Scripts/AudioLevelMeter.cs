using UnityEngine;

public class AudioLevelMeter : MonoBehaviour
{
    public float integrationTime = 1f;
    public float dBLeftChannel; // Current left channel level in decibels
    public float dBRightChannel; // Current right channel level in decibels

    private float leftDecibelValue; // Current left channel level in decibels
    private float rightDecibelValue; // Current right channel level in decibels
    private float leftRmsValue; // RMS value of the left channel
    private float rightRmsValue; // RMS value of the right channel
    private float smoothingFactor; // Exponential smoothing factor
    private float integrationTime_old;
    private float timeCount;


    void Start()
    {
        
        smoothingFactor = Mathf.Exp(-1.0f / integrationTime);
        integrationTime_old = integrationTime;

    }

    void OnAudioFilterRead(float[] data, int channels)
    {
        if (channels < 2)
        {
            Debug.LogWarning("Audio source must be stereo for separate left and right channel processing.");
            return;
        }

        // Calculate RMS values for left and right channels
        float leftSum = 0f;
        float rightSum = 0f;

        for (int i = 0; i < data.Length; i += channels)
        {
            leftSum += data[i] * data[i];
            rightSum += data[i + 1] * data[i + 1];
        }

        float currentLeftRMS = Mathf.Sqrt(leftSum / (data.Length / channels));
        float currentRightRMS = Mathf.Sqrt(rightSum / (data.Length / channels));

        // Apply exponential smoothing to RMS values
        leftRmsValue = Mathf.Lerp(leftRmsValue, currentLeftRMS, 1.0f - smoothingFactor);
        rightRmsValue = Mathf.Lerp(rightRmsValue, currentRightRMS, 1.0f - smoothingFactor);

        // Convert RMS to decibels
        leftDecibelValue = 20f * Mathf.Log10(leftRmsValue + 1e-6f); // Adding a small offset to prevent log of zero
        rightDecibelValue = 20f * Mathf.Log10(rightRmsValue + 1e-6f);
    }

    void Update()
    {
        timeCount += Time.deltaTime;

        if (integrationTime!=integrationTime_old)
        {
            smoothingFactor = Mathf.Exp(-1.0f / integrationTime);
            integrationTime_old = integrationTime;

        }

        // so that display update corresponds to integration time
        if (timeCount >= integrationTime)
        {
            dBLeftChannel = leftDecibelValue;
            dBRightChannel = rightDecibelValue;
            timeCount = 0f;
        }
    }
        
}
