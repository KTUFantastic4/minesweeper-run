using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderScript : MonoBehaviour
{
    public Slider ui;
    
    void Start()
    {
        OptionData data = SaveSystem.LoadOption();
        if(data != null)
        {
            ui.value = data.volume;
            
           
        }
        else
        {
            Debug.Log("Uzsaugoto garso failas nerastas");
        }
    }

    
}
