using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderEffect : MonoBehaviour
{
    public Slider ui;

    void Start()
    {
        OptionData data = SaveSystem.LoadOption();
        if (data != null)
        {
            ui.value = data.soundEffect;


        }
        else
        {
            Debug.Log("Uzsaugoto garso failas nerastas");
        }
    }
}
