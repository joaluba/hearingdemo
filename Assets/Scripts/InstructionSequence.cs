using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionSequence : MonoBehaviour
{
    public GameObject PreviousCanvas;
    public GameObject CurrentCanvas;
    public GameObject NextCanvas;


    public void GoToNextCanvas()
    {
        CurrentCanvas.gameObject.SetActive(false);
        NextCanvas.gameObject.SetActive(true);

    }

    public void GoToPreviousCanvas()
    {
        CurrentCanvas.gameObject.SetActive(false);
        PreviousCanvas.gameObject.SetActive(true);

    }


    public void ActivateNewScene()
    {
        
        Scene scene= SceneManager.GetActiveScene();
        int idx = scene.buildIndex;
        SceneManager.LoadScene(idx+1);
        
    }

}
