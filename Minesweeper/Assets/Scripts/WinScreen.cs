using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public Text timerText;
    private float startTime;
    private bool finnished = false;

    public GameObject winScreen;
    //private bool isWon = false;
    void Start()
    {
        winScreen.SetActive(false);
        
    }
    // Update is called once per frame
    void Update()
    {
        if(FindObjectOfType<MovementController>().isWon)
        {
            Show();
        }
    }

    void Show()
    {
        if (finnished)
        {
            return;
        }
        float t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString("00");
        string seconds = (t % 60).ToString("00");

        timerText.text = "Level beaten in: " + minutes + "minutes " + seconds + "seconds";
        winScreen.SetActive(true);
        //FindObjectOfType<AudioManager>().Play("TF2Victory");
        
        FindObjectOfType<AudioManager>().Play("GtaWin");
        enabled = false;
        FindObjectOfType<GameOverMeniu>().enabled = false;
        FindObjectOfType<AudioManager>().Stop("Background_Music");
        StartCoroutine(StopMovementAfterTime(6));
        
    }
    IEnumerator StopMovementAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        finnished = true;
        FindObjectOfType<MovementController>().CancelInvoke();
        FindObjectOfType<MovementController>().enabled = false;
        
        //winScreen.SetActive(false);
    }
    public void NextLevel()
    {
        FindObjectOfType<MovementController>().isWon = false;
        enabled = true;
        winScreen.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Restart()
    {
        Debug.Log("Restarting...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        winScreen.SetActive(false);
        enabled = true;
    }
    public void MainMenu()
    {
        Debug.Log("Loading Main Menu...");
        SceneManager.LoadScene("Menu");
        
        
    }
}
