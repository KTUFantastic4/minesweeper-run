using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMeniu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool meniuIsOff = false;
    public GameObject gameOverMenuUI;
    public MovementController player;
    public static bool gameIsOver = true;
    //public BasicCameraFollow camera;
    
    // Update is called once per frame
    void Update()
    {
       
            
            if (player.isDead)
            {
                Show();
            }

        if(gameIsOver)
        {
            gameOverMenuUI.SetActive(false);
        }
        
    }
    
    void Show()
    {
        gameOverMenuUI.SetActive(true);
        
        player.isDead = true;
        
        player.CancelInvoke();
        gameIsOver = false;
        
        
    }
    public void RestartGame()
    {
        Debug.Log("Restarting...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        
        gameOverMenuUI.SetActive(false);
        meniuIsOff = false;
        Time.timeScale = 1f;
        player.isDead = false;
        
        
        gameIsOver = true;

    }
    public void QuitGame()
    {
        Debug.Log("Quitting Game ...");
        Application.Quit();
        
    }
    public void MainMenu()
    {
        Debug.Log("Loading Main Menu...");
        SceneManager.LoadScene("Menu");
        gameOverMenuUI.SetActive(false);
        player.isDead = false;
        gameIsOver = true;
    }
}
