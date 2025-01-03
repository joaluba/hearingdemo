using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SteamAudio;
using TMPro;

public class ControlSOFADropdown : MonoBehaviour
{

    [SerializeField] TMP_Dropdown SOFADropdown;
    SteamAudioManager my_SteamAudioManager;

    void Start()
    {

        // Steam Audio Manager is an object created by Steam Audio in the play mode
        // it contains options for SOFA files 
        my_SteamAudioManager  = GameObject.Find("Steam Audio Manager").GetComponent<SteamAudioManager>();


        print(my_SteamAudioManager.currentHRTF);
        print(my_SteamAudioManager.hrtfNames[0]);


        // Fill dropdown menu with options from Steam Audio Manager:
        SOFADropdown.options.Clear();
        foreach (string t in my_SteamAudioManager.hrtfNames)
        {
            SOFADropdown.options.Add(new TMP_Dropdown.OptionData() { text = t });
        }
    }


    public void ChangeSOFA()
    {

        my_SteamAudioManager.currentHRTF=SOFADropdown.value;
    }

}




