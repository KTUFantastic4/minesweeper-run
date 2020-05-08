using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
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
        winScreen.SetActive(true);
        FindObjectOfType<AudioManager>().Play("TF2Victory");
        enabled = false;
        FindObjectOfType<GameOverMeniu>().enabled = false;
        FindObjectOfType<AudioManager>().Stop("Background_Music");
        StartCoroutine(StopMovementAfterTime(6));
        
    }
    IEnumerator StopMovementAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

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
