using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class OptionData
{
    public float volume;
    public float soundEffect;
    public OptionData(float vol)
    {
        volume = vol;
        soundEffect = 1f;
    }
    public OptionData(float vol,float effect)
    {
        volume = vol;
        soundEffect = effect;
    }
}
