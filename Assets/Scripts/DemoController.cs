using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using ReadyPlayerMe.Core;
using UnityEngine.UI;

public class DemoController : MonoBehaviour
{

    public GameObject StillAvatars;
    public GameObject ActiveAvatars;
    public Button[] ChoiceButtons;
    public AudioSource[] AvatarSources;
    public AudioSource TimeRefSource;
    public PlayableDirector Timeline;

    private int Playbacktime;

    private int SrcIdx;

    // Start is called before the first frame update
    void Start()
    {
        SrcIdx = 0;

    }

    private void OnEnable()
    {
        Timeline.time = 0;
        // Loop through all immediate children
        for (int i = 0; i < AvatarSources.Length; i++)
        {
            VoiceHandler voiceHandler = ActiveAvatars.transform.GetChild(i).GetComponent<VoiceHandler>();
            voiceHandler.AudioSource.time = 0;
            voiceHandler.AudioSource.Play();
        }

        StillAvatars.SetActive(false);
        ActiveAvatars.SetActive(true);
        ChangeSource(ChoiceButtons[SrcIdx]);
    }

    void OnDisable()
    {

        // Loop through all immediate children
        for (int i = 0; i < AvatarSources.Length; i++)
        {
            AudioSource[] audiosperavatar = AvatarSources[i].GetComponents<AudioSource>();
            VoiceHandler voiceHandler = ActiveAvatars.transform.GetChild(i).GetComponent<VoiceHandler>();

            MuteAllSources(audiosperavatar);
            voiceHandler.AudioSource.time = 0;
            voiceHandler.AudioSource.Stop();
        }
    }




    public void UnmuteOneSource(AudioSource[] audioSources, int AudioCondition)
    {

        float time= TimeRefSource.time;
        int c = 0;
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.volume = 0.8f;
            {

                if (c == AudioCondition)
                {
                    audioSource.enabled = true;
                    audioSource.time = time;
                    audioSource.mute = false;
                }

                else
                {
                    audioSource.enabled = false;
                    audioSource.mute = true;
                  
                }

                c++;
            }
        }
    }


    public void MuteAllSources(AudioSource[] audioSources)
    {
        foreach (AudioSource audioSource in audioSources)
        {

            audioSource.mute = true;
            audioSource.enabled = false;

        }
    }


    public void ChangeSource(Button thisbutton)
    {

        if (thisbutton.name == "Coherent")
        {
            SrcIdx = 0;
        }
        else if (thisbutton.name == "Incoherent")
        {
            SrcIdx = 1;
        }
        else if (thisbutton.name == "SigProc")
        {
            SrcIdx = 3;
        }
        else if (thisbutton.name == "DNN2020")
        {
            SrcIdx = 4;
        }
        else if (thisbutton.name == "DNN2023")
        {
            SrcIdx = 5;
        }


        foreach (Button button in ChoiceButtons)
        {
            if (button.name == thisbutton.name)
            {
                print(button.name);
                ColorBlock cb = button.colors;
                cb.normalColor = Color.green;
                cb.highlightedColor = Color.green;
                cb.pressedColor = Color.green;
                cb.selectedColor = Color.green;
                button.colors = cb;
            }
            else
            {
                ColorBlock cb = button.colors;
                cb.normalColor = Color.white;
                cb.highlightedColor = Color.white;
                cb.pressedColor = Color.white;
                cb.selectedColor = Color.white;
                button.colors = cb;
            }

        }



        // Loop through all immediate children
        for (int i = 0; i < AvatarSources.Length; i++)
        {
          AudioSource[] audiosperavatar = AvatarSources[i].GetComponents<AudioSource>();
          UnmuteOneSource(audiosperavatar, SrcIdx);

        }



    }

}
