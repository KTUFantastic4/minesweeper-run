using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void Start()
    {
        Debug.Log("pradedam");
        //FindObjectOfType<AudioManager>().Play("Background_Music");
    }
    public void PlayGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
    public void SetSound(float volume)
    {
        //Debug.Log(volume);
        audioMixer.SetFloat("Volume",volume);
        FindObjectOfType<AudioManager>().SetVolume(volume, "Background_Music");
        SaveSystem.SaveOptions(volume);
    }

}