using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
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

        Debug.Log("veik");
        if (!isMuted)
        {


            Debug.Log("Muting");
            FindObjectOfType<AudioManager>().Mute("Background_Music",true);
            isMuted = true;


        }
        else
        {
            Debug.Log("Unmuting");
            FindObjectOfType<AudioManager>().Mute("Background_Music",false);
            isMuted = false;

        }


    }
    public void SetSound(float volume)
    {
        //Debug.Log(volume);
        //audioMixer.SetFloat("Volume", volume);
        FindObjectOfType<AudioManager>().SetVolume(volume, "Background_Music");
    }
}
