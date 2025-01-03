using System;

public class AudioParameters
{
    // HA3DTI parameters
    public float HA3DTI_Handle { get; set; }
    public float HA3DTI_Limiter_On { get; set; }
    public float HA3DTI_NoiseBits { get; set; }
    public float HA3DTI_NoiseBefore_On { get; set; }
    public float HA3DTI_NoiseAfter_On { get; set; }
    public float HA3DTI_floaterpolation_On { get; set; }
    public float HA3DTI_HPF_Cutoff { get; set; }
    public float HA3DTI_LPF_Cutoff { get; set; }
    public float HA3DTI_Get_Limiter_Compression { get; set; }

    public float HA3DTI_Process_LeftOn { get; set; }
    public float HA3DTI_Process_RightOn { get; set; }

    public float HA3DTI_AttackRelease_Left { get; set; }
    public float HA3DTI_AttackRelease_Right { get; set; }

    public float HA3DTI_Normalization_LeftOn { get; set; }
    public float HA3DTI_Normalization_RightOn { get; set; }

    public float HA3DTI_Normalization_DB_Left { get; set; }
    public float HA3DTI_Normalization_DB_Right { get; set; }

    public float HA3DTI_Normalization_Get_Left { get; set; }
    public float HA3DTI_Normalization_Get_Right { get; set; }

    public float HA3DTI_Compression_Left { get; set; }
    public float HA3DTI_Compression_Right { get; set; }

    public float HA3DTI_Tone_Low_Left { get; set; }
    public float HA3DTI_Tone_Mid_Left { get; set; }
    public float HA3DTI_Tone_High_Left { get; set; }
    public float HA3DTI_Tone_Low_Right { get; set; }
    public float HA3DTI_Tone_Mid_Right { get; set; }
    public float HA3DTI_Tone_High_Right { get; set; }

    public float HA3DTI_Volume_Left { get; set; }
    public float HA3DTI_Volume_Right { get; set; }

    public float HA3DTI_Gain_Level_0_Band_0_Left { get; set; }
    public float HA3DTI_Gain_Level_0_Band_1_Left { get; set; }
    public float HA3DTI_Gain_Level_0_Band_2_Left { get; set; }
    public float HA3DTI_Gain_Level_0_Band_3_Left { get; set; }
    public float HA3DTI_Gain_Level_0_Band_4_Left { get; set; }
    public float HA3DTI_Gain_Level_0_Band_5_Left { get; set; }
    public float HA3DTI_Gain_Level_0_Band_6_Left { get; set; }

    public float HA3DTI_Gain_Level_1_Band_0_Left { get; set; }
    public float HA3DTI_Gain_Level_1_Band_1_Left { get; set; }
    public float HA3DTI_Gain_Level_1_Band_2_Left { get; set; }
    public float HA3DTI_Gain_Level_1_Band_3_Left { get; set; }
    public float HA3DTI_Gain_Level_1_Band_4_Left { get; set; }
    public float HA3DTI_Gain_Level_1_Band_5_Left { get; set; }
    public float HA3DTI_Gain_Level_1_Band_6_Left { get; set; }

    public float HA3DTI_Gain_Level_2_Band_0_Left { get; set; }
    public float HA3DTI_Gain_Level_2_Band_1_Left { get; set; }
    public float HA3DTI_Gain_Level_2_Band_2_Left { get; set; }
    public float HA3DTI_Gain_Level_2_Band_3_Left { get; set; }
    public float HA3DTI_Gain_Level_2_Band_4_Left { get; set; }
    public float HA3DTI_Gain_Level_2_Band_5_Left { get; set; }
    public float HA3DTI_Gain_Level_2_Band_6_Left { get; set; }

    public float HA3DTI_Gain_Level_0_Band_0_Right { get; set; }
    public float HA3DTI_Gain_Level_0_Band_1_Right { get; set; }
    public float HA3DTI_Gain_Level_0_Band_2_Right { get; set; }
    public float HA3DTI_Gain_Level_0_Band_3_Right { get; set; }
    public float HA3DTI_Gain_Level_0_Band_4_Right { get; set; }
    public float HA3DTI_Gain_Level_0_Band_5_Right { get; set; }
    public float HA3DTI_Gain_Level_0_Band_6_Right { get; set; }

    public float HA3DTI_Gain_Level_1_Band_0_Right { get; set; }
    public float HA3DTI_Gain_Level_1_Band_1_Right { get; set; }
    public float HA3DTI_Gain_Level_1_Band_2_Right { get; set; }
    public float HA3DTI_Gain_Level_1_Band_3_Right { get; set; }
    public float HA3DTI_Gain_Level_1_Band_4_Right { get; set; }
    public float HA3DTI_Gain_Level_1_Band_5_Right { get; set; }
    public float HA3DTI_Gain_Level_1_Band_6_Right { get; set; }

    public float HA3DTI_Gain_Level_2_Band_0_Right { get; set; }
    public float HA3DTI_Gain_Level_2_Band_1_Right { get; set; }
    public float HA3DTI_Gain_Level_2_Band_2_Right { get; set; }
    public float HA3DTI_Gain_Level_2_Band_3_Right { get; set; }
    public float HA3DTI_Gain_Level_2_Band_4_Right { get; set; }
    public float HA3DTI_Gain_Level_2_Band_5_Right { get; set; }
    public float HA3DTI_Gain_Level_2_Band_6_Right { get; set; }

    public float HA3DTI_Threshold_0_Left { get; set; }
    public float HA3DTI_Threshold_0_Right { get; set; }

    public float HA3DTI_Threshold_1_Left { get; set; }
    public float HA3DTI_Threshold_1_Right { get; set; }

    public float HA3DTI_Threshold_2_Left { get; set; }
    public float HA3DTI_Threshold_2_Right { get; set; }

    // HL3DTI parameters
    public float HL3DTI_Process_LeftOn { get; set; }
    public float HL3DTI_Process_RightOn { get; set; }

    public float HL3DTI_TA_LeftOn { get; set; }
    public float HL3DTI_TA_RightOn { get; set; }

    public float HL3DTI_MBE_LeftOn { get; set; }
    public float HL3DTI_MBE_RightOn { get; set; }

    public float HL3DTI_FS_LeftOn { get; set; }
    public float HL3DTI_FS_RightOn { get; set; }

    public float HL3DTI_TA_LRSync_On { get; set; }
    public float HL3DTI_TA_LRSync { get; set; }

    public float HL3DTI_TA_Band_Left { get; set; }
    public float HL3DTI_TA_Band_Right { get; set; }

    public float HL3DTI_TA_Noise_Power_Left { get; set; }
    public float HL3DTI_TA_Noise_Power_Right { get; set; }

    public float HL3DTI_TA_Noise_LPF_Left { get; set; }
    public float HL3DTI_TA_Noise_LPF_Right { get; set; }

    public float HL3DTI_TA_Autocor0_Get_Left { get; set; }
    public float HL3DTI_TA_Autocor0_Get_Right { get; set; }

    public float HL3DTI_TA_Autocor1_Get_Left { get; set; }
    public float HL3DTI_TA_Autocor1_Get_Right { get; set; }

    public float HL3DTI_HL_Band_0_Left { get; set; }
    public float HL3DTI_HL_Band_1_Left { get; set; }
    public float HL3DTI_HL_Band_2_Left { get; set; }
    public float HL3DTI_HL_Band_3_Left { get; set; }
    public float HL3DTI_HL_Band_4_Left { get; set; }
    public float HL3DTI_HL_Band_5_Left { get; set; }
    public float HL3DTI_HL_Band_6_Left { get; set; }
    public float HL3DTI_HL_Band_7_Left { get; set; }
    public float HL3DTI_HL_Band_8_Left { get; set; }

    public float HL3DTI_HL_Band_0_Right { get; set; }
    public float HL3DTI_HL_Band_1_Right { get; set; }
    public float HL3DTI_HL_Band_2_Right { get; set; }
    public float HL3DTI_HL_Band_3_Right { get; set; }
    public float HL3DTI_HL_Band_4_Right { get; set; }
    public float HL3DTI_HL_Band_5_Right { get; set; }
    public float HL3DTI_HL_Band_6_Right { get; set; }
    public float HL3DTI_HL_Band_7_Right { get; set; }
    public float HL3DTI_HL_Band_8_Right { get; set; }

    public float HL3DTI_FS_Hz_Up_Left { get; set; }
    public float HL3DTI_FS_Hz_Up_Right { get; set; }

    public float HL3DTI_FS_Size_Down_Left { get; set; }
    public float HL3DTI_FS_Size_Down_Right { get; set; }

    public float HL3DTI_FS_Hz_Down_Left { get; set; }
    public float HL3DTI_FS_Hz_Down_Right { get; set; }

    public float HL3DTI_FS_Size_Up_Left { get; set; }
    public float HL3DTI_FS_Size_Up_Right { get; set; }

    public float HL3DTI_HL_FS_Approach_Left { get; set; }
    public float HL3DTI_HL_FS_Approach_Right { get; set; }

    public float HL3DTI_HL_MBE_Approach_Left { get; set; }
    public float HL3DTI_HL_MBE_Approach_Right { get; set; }

    public float HL3DTI_Calibration { get; set; }
}

