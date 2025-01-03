using UnityEngine;
using UnityEngine.Audio;
using System.IO;
using System.Collections;
using API_3DTI;


public class MyHLHAController : MonoBehaviour
{
    public string whichhearingloss; // string type
    public string whichhearingaid; // string type
    private string whichhearingloss_old; // string type
    private string whichhearingaid_old; // string type
    public HearingLoss HearingLossComponenet; // HL componenet assigned to main camera (unity wrapper script by 3dTI)
    public HearingAid HearingAidComponent; // HA componenet assigned to main camera (unity wrapper script by 3dTI)


    // parameters from the Unity Wrapper needed to set parameters
    private T_ear ear;
    private HearingLoss.T_HLClassificationScaleCurve curve;
    private HearingLoss.T_HLClassificationScaleSeverity severity;
    private int slope;

    void Start()
    {
        whichhearingloss_old = whichhearingloss;
        whichhearingaid_old = whichhearingaid;

        // Declare a variable of the enum type
        ChooseHL(whichhearingloss);


    }

    void Update()
    {

        if (whichhearingloss!= whichhearingloss_old)
        {
            ChooseHL(whichhearingloss);
            whichhearingloss_old = whichhearingloss;
        }
        if (whichhearingaid_old != whichhearingaid)
        {
            ChooseHL(whichhearingaid);
            whichhearingaid_old = whichhearingaid;
        }



    }




    public void ChooseHL(string whichhl)
    {

        bool is_AudiometrySet = false;
        bool is_HLSwitchSet = false;

        if (whichhl=="mild")
        {
            Debug.Log("Setting params for mild HL");
            ear = T_ear.BOTH;
            curve = HearingLoss.T_HLClassificationScaleCurve.HL_CS_A;
            slope = 2;
            severity = HearingLoss.T_HLClassificationScaleSeverity.HL_CS_SEVERITY_MILD;
            is_AudiometrySet = HearingLossComponenet.SetAudiometryFromClassificationScale(ear,curve, slope, severity);
            is_HLSwitchSet = HearingLossComponenet.SetParameter(HearingLoss.Parameter.HLOn, true, T_ear.BOTH);
        }
        else if (whichhl == "moderate")
        {
            Debug.Log("Setting params for moderate HL");
            ear = T_ear.BOTH;
            curve = HearingLoss.T_HLClassificationScaleCurve.HL_CS_B;
            slope = 3;
            severity = HearingLoss.T_HLClassificationScaleSeverity.HL_CS_SEVERITY_MODERATE;
            is_AudiometrySet = HearingLossComponenet.SetAudiometryFromClassificationScale(ear, curve, slope, severity);
            is_HLSwitchSet = HearingLossComponenet.SetParameter(HearingLoss.Parameter.HLOn, true, T_ear.BOTH);
        }
        else if (whichhl == "severe")
        {

            Debug.Log("Setting params for severe HL");
            ear = T_ear.BOTH;
            curve = HearingLoss.T_HLClassificationScaleCurve.HL_CS_B;
            slope = 3;
            severity = HearingLoss.T_HLClassificationScaleSeverity.HL_CS_SEVERITY_SEVERE;
            is_AudiometrySet = HearingLossComponenet.SetAudiometryFromClassificationScale(ear, curve, slope, severity);
            is_HLSwitchSet = HearingLossComponenet.SetParameter(HearingLoss.Parameter.HLOn, true, T_ear.BOTH);
        }
        else if (whichhl == "none")
        {
            is_AudiometrySet = true;
            is_HLSwitchSet = HearingLossComponenet.SetParameter(HearingLoss.Parameter.HLOn, false, T_ear.BOTH);
        }


        if (is_AudiometrySet && is_HLSwitchSet)
        {
            Debug.Log("Hearing Loss Parameters Have Been Set");
        }
        else
        {
            Debug.Log("CAREFUL! Params have not been set, something is off.");
        }


    }

 
    //private void ChooseHA(string whichhl)
    //{
    //    if (whichhl == "mild")
    //    {

    //    }
    //    else if (whichhl == "moderate")
    //    {

    //    }
    //    else if (whichhl == "severe")
    //    {

    //    }
    //}

}


