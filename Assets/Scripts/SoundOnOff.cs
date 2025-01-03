using UnityEngine;
using System.Collections;

public class SoundOnOff : MonoBehaviour
{

    private bool clicked = false;


    public void ClickSource()
    {
        if (clicked == false)
        {
            SourceOn();
            clicked = true;
        }
        else if (clicked == true)
        {
            SourceOff();
            clicked = false;
        }
    }

    public void SourceOn()
    {
        GetComponent<AudioSource>().mute = false;
        GetComponent<Renderer>().material.color = Color.green;
    }

    public void SourceOff()
    {
        GetComponent<AudioSource>().mute = true;
        GetComponent<Renderer>().material.color = Color.white;
    }




}
    