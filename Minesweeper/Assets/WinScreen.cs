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
        
    }
    public void NextLevel()
    {
        FindObjectOfType<MovementController>().isWon = false;
        enabled = true;
        winScreen.SetActive(false);
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
