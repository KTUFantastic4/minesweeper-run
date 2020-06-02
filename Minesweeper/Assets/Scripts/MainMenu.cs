using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider backgroundMusic;
    public Slider soundEffect;
    public void Start()
    {
        Debug.Log("pradedam");
        OptionData data = SaveSystem.LoadOption();
        Debug.Log("Ha");
        soundEffect.value = data.soundEffect;
        backgroundMusic.value = data.volume;
        soundEffect.value = data.soundEffect;
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
        SaveSystem.SaveOptions(volume,soundEffect.value);
    }
    public void SaveEffectSound(float effect)
    {
        soundEffect.value = effect;
        SaveSystem.SaveOptions(backgroundMusic.value, effect);
    }

}