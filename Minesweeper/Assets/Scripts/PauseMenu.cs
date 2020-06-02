using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public Slider slider;
    public Button panel;
    public static bool isPaused = false;
    public static bool isMuted = false;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        isPaused = true;
        
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
    }
    public void MainMenu()
    {

        Debug.Log("Loading Main Menu...");
        SceneManager.LoadScene("Menu");
    }
    public void MuteSound()
    {
        var col = panel.colors;
        var selectedColor = col.selectedColor;
        Debug.Log("veik");
        if (!isMuted)
        {


            Debug.Log("Muting");
            isMuted = true;
            selectedColor.a = 0.8f;
            col.selectedColor = selectedColor;
            panel.colors = col;
            panel.Select();
            FindObjectOfType<AudioManager>().SetVolume(0, "Background_Music");
            slider.value = 0;
            


        }
        else
        {
            Debug.Log("Unmuting");
            OptionData data = SaveSystem.LoadOption();
            
            selectedColor.a = 0f;
            col.selectedColor = selectedColor;
            col.highlightedColor = Color.green;
            
            panel.colors = col;
            if(data != null)
            {
                //FindObjectOfType<AudioManager>().SetVolume(data.volume, "Background_Music");
                isMuted = false;
                slider.value = data.volume;
            }
            else
            {
                Debug.Log("Nepavyko gauti garso stiprumo is failo");
            }
            

        }


    }
    public void SetSound(float volume)
    {
        //Debug.Log(volume);
        //audioMixer.SetFloat("Volume", volume);
       if(volume >0)
        {
            isMuted = false;
        }
        if(!isMuted)
        {
            FindObjectOfType<AudioManager>().SetVolume(volume, "Background_Music");
            
            SaveSystem.SaveOptions(volume);
        }
    }
}
