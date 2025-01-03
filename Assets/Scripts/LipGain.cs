using System.Collections;
using System.Collections.Generic;
using ReadyPlayerMe.Core;
using UnityEngine;


public class LipGain : MonoBehaviour
{
    private VoiceHandler thisVoiceHandler;
    public int LipGainValue;
    // Start is called before the first frame update
    void Start()
    {
        thisVoiceHandler = GetComponent<VoiceHandler>();
        thisVoiceHandler.AMPLITUDE_MULTIPLIER = LipGainValue;
    }

}
