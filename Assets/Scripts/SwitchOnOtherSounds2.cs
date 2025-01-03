using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using ReadyPlayerMe.Core;


public class SwitchOnOtherSounds2 : MonoBehaviour
{

    public GameObject Joanna;
    private AudioSource JoannaTalking;
    public GameObject StillAvatars;
    public GameObject ActiveAvatars;
    public GameObject MainOrder;
    public GameObject Panel;
    public GameObject PanelConversation;
    public PlayableDirector Timeline;
    public float HowLongConversation;
    public int AudioCondition;
    public AudioSource[] AvatarSources;
    private bool AreNewSrcsOn;




    // Start is called before the first frame update
    void Start()
    {
        AreNewSrcsOn = false;
        JoannaTalking = Joanna.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!JoannaTalking.isPlaying && !AreNewSrcsOn)
        {
            AreNewSrcsOn = true;
            JoannaTalking.Stop();
            StartCoroutine(Conversation());
       
        }
    }


    private void OnEnable()
    {
        // Loop through all immediate children
        for (int i = 0; i < AvatarSources.Length; i++)
        {
            AudioSource[] audiosperavatar = AvatarSources[i].GetComponents<AudioSource>();
            UnmuteOneSource(audiosperavatar, AudioCondition);

        }
    }

    void OnDisable()
    {
        Joanna.SetActive(true);
        Panel.SetActive(true);
        JoannaTalking.mute = false;
        StillAvatars.SetActive(true);
        ActiveAvatars.SetActive(false);
        PanelConversation.SetActive(false);
        AreNewSrcsOn = false;

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



    IEnumerator Conversation()
    {
        // Loop through all immediate children
        for (int i = 0; i < AvatarSources.Length; i++)
        {
            VoiceHandler voiceHandler = ActiveAvatars.transform.GetChild(i).GetComponent<VoiceHandler>();

            voiceHandler.AudioSource.time = 0;
            voiceHandler.AudioSource.Play();
        }

        Timeline.time = 0;
        Joanna.SetActive(false);
        StillAvatars.SetActive(false);
        //Panel.SetActive(false);
        PanelConversation.SetActive(true);
        ActiveAvatars.SetActive(true);
        yield return new WaitForSeconds(HowLongConversation);
        MainOrder.GetComponent<InstructionSequence>().GoToNextCanvas();

    }

    public void UnmuteOneSource(AudioSource[] audioSources, int AudioCondition)
    {
        int c = 0;
        foreach (AudioSource audioSource in audioSources)
        {
            {
                if (c < 3)
                {
                    print(" Switching on Audio:" + audioSource.clip.name);

                    if (c == AudioCondition)
                    {
                        audioSource.enabled = true;
                        audioSource.mute = false;
                    }

                    c++;
                }

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


}
