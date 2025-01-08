using UnityEngine;

public class AudioLevelCompare : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioListener audioListener;
    public float SrcLevelLeft;
    public float SrcLevelRight;
    public float ListenLevelLeft;
    public float ListenLevelRight;
    public float integrationTime = 1f;

    private const int sampleSize = 1024; // Number of samples to process
    private float[] sourceSamples = new float[sampleSize];
    private float[] listenerSamples = new float[sampleSize];

    private float smoothingFactor; // Exponential smoothing factor
    private float integrationTime_old;
    private float timeCount;


    private float SrcRmsLeft_tmp;
    private float SrcRmsRight_tmp;
    private float ListenRmsLeft_tmp;
    private float ListenRmsRight_tmp;

    private float SrcRmsLeft_old=0;
    private float SrcRmsRight_old=0;
    private float ListenRmsLeft_old=0;
    private float ListenRmsRight_old=0;

    private float SrcLevelLeft_tmp;
    private float SrcLevelRight_tmp;
    private float ListenLevelLeft_tmp;
    private float ListenLevelRight_tmp;



    private void Start()
    {

        smoothingFactor = Mathf.Exp(-1.0f / integrationTime);
        integrationTime_old = integrationTime;
    }

    void Update()
    {

        timeCount += Time.deltaTime;

        smoothingFactor = Mathf.Exp(timeCount/ integrationTime);



        // get rms of the current audio batch 
        SrcRmsLeft_tmp = GetAudioSourceRms(0);
        SrcRmsRight_tmp = GetAudioSourceRms(1);
        ListenRmsLeft_tmp = GetAudioListenerRms(0);
        ListenRmsRight_tmp = GetAudioListenerRms(1);


        //// get level of the current audio batch (taking into account previous batches)
        //SrcLevelLeft_tmp = SmoothAndGoTodB(SrcRmsLeft_tmp, SrcRmsLeft_old, smoothingFactor);
        //SrcLevelRight_tmp = SmoothAndGoTodB(SrcRmsRight_tmp, SrcRmsRight_old, smoothingFactor);
        //ListenLevelLeft_tmp = SmoothAndGoTodB(ListenRmsLeft_tmp, ListenRmsLeft_old, smoothingFactor);
        //ListenLevelRight_tmp = SmoothAndGoTodB(ListenRmsRight_tmp, ListenRmsRight_old, smoothingFactor);


        // get level of the current audio batch (taking into account previous batches)
        SrcLevelLeft_tmp = GoTodB(SrcRmsLeft_tmp);
        SrcLevelRight_tmp = GoTodB(SrcRmsRight_tmp);
        ListenLevelLeft_tmp = GoTodB(ListenRmsLeft_tmp);
        ListenLevelRight_tmp = GoTodB(ListenRmsRight_tmp);


        // so that display update corresponds to integration time
        if (timeCount >= integrationTime)
        {
            SrcLevelLeft = SrcLevelLeft_tmp;
            SrcLevelRight = SrcLevelRight_tmp;
            ListenLevelLeft = ListenLevelLeft_tmp;
            ListenLevelRight = ListenLevelRight_tmp;
            timeCount = 0f;
        }

        Debug.Log("timeCount=" + timeCount);
        Debug.Log("smoothing Factor=" + smoothingFactor);
        Debug.Log("rms old=" + SrcRmsLeft_old);
        Debug.Log("rms tmp=" + SrcRmsLeft_tmp);
        Debug.Log("level tmp=" + SrcLevelLeft_tmp);

        // update rms values 
        SrcRmsLeft_old = SrcRmsLeft_tmp;
        SrcRmsRight_old = SrcRmsRight_tmp;
        ListenRmsLeft_old = ListenRmsLeft_tmp;
        ListenRmsLeft_old = ListenRmsLeft_tmp;





    }

    private float GetAudioSourceRms(int channel)
    {
        if (audioSource == null)
        {
            Debug.LogError("AudioSource is not assigned!");
            return 0f;
        }

        // Get samples from the AudioSource
        audioSource.GetOutputData(sourceSamples, channel);


        // Calculate RMS level
        return CalculateRMS(sourceSamples);
    }

    private float GetAudioListenerRms(int channel)
    {
        if (audioListener == null)
        {
            Debug.LogError("AudioListener is not assigned!");
            return 0f;
        }

        // Get samples from the AudioListener
        AudioListener.GetOutputData(listenerSamples, channel);

        // Calculate RMS level
        return CalculateRMS(listenerSamples);
    }

    private float CalculateRMS(float[] samples)
    {
        float sum = 0f;

        foreach (float sample in samples)
        {
            sum += sample * sample;
        }

        return Mathf.Sqrt(sum / samples.Length);
    }


    private float SmoothAndGoTodB(float rms, float rms_old, float smoothingFactor)
    {
        // Apply exponential smoothing to RMS values
        rms = Mathf.Lerp(rms_old, rms, 1.0f - smoothingFactor);

        // Convert RMS to decibels
        float L_smooth = 20f * Mathf.Log10(rms + 1e-6f); 

        return L_smooth;
    }



    private float GoTodB(float rms)
    {

        // Convert RMS to decibels
        float L_smooth = 20f * Mathf.Log10(rms + 1e-6f);

        return L_smooth;
    }
}