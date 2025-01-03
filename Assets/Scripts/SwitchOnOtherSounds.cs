using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchOnOtherSounds : MonoBehaviour
{

    public AudioSource FirstSource;
    public GameObject NextSources;
    private bool AreNewSrcsOn;
    // Start is called before the first frame update
    void Start()
    {
        AreNewSrcsOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!FirstSource.isPlaying && !AreNewSrcsOn)
        {
            NextSources.SetActive(true);
            AreNewSrcsOn = true;
        }
    }


    void OnDisable()
    {
        
        NextSources.SetActive(false);
        AreNewSrcsOn = false;
    }
}
