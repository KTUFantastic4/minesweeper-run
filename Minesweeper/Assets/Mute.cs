using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Mute : MonoBehaviour
{
    bool isMuted=false;
    //void Start()
    //{
    //    isMuted = false;
    //}
   
    //private void Awake()
    //{
    //    _button = GetComponent<Button>();
    //}
    
    public void MuteSound()
    {
        
        Debug.Log("veik");
        if (!isMuted)
        {


            Debug.Log("Muting");
            FindObjectOfType<AudioManager>().Stop("Background_Music");
            isMuted = true;


        }
        else
        {
            Debug.Log("Unmuting");
            FindObjectOfType<AudioManager>().Play("Background_Music");
            isMuted = false;

        }


    }
}
