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
        if (gameIsOver)
        {
            //FindObjectOfType<AudioManager>().Play("Explotion");
            FindObjectOfType<AudioManager>().Play("DancingCoffin");
        }
        gameOverMenuUI.SetActive(true);
        //Bag [] bybiai = FindObjectsOfType<Bag>();
        //foreach(Bag bybys in bybiai)
        //{
        //    bybys.gameObject.SetActive(false);
        //    bybys.isClosed = true;
        //}
        
        FindObjectOfType<Bag>().isClosed = false;
        FindObjectOfType<Bag>().gameObject.SetActive(false);
        player.isDead = true;
        
        //player.CancelInvoke();
        gameIsOver = false;
        
        
    }
    //RestartGame
    public void MainMenu()
    {
        //Debug.Log("Restarting...");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        
        //gameOverMenuUI.SetActive(false);
        //meniuIsOff = false;
        //Time.timeScale = 1f;
        //player.isDead = false;
        
        
        //gameIsOver = true;
        gameIsOver = true;
        Debug.Log("Loading Main Menu...");
        SceneManager.LoadScene("Menu");
        gameOverMenuUI.SetActive(false);
        player.isDead = false;
        gameIsOver = true;

    }
    public void QuitGame()
    {
        Debug.Log("Quitting Game ...");
        Application.Quit();
        
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
        //Debug.Log("Loading Main Menu...");
        //SceneManager.LoadScene("Menu");
        //gameOverMenuUI.SetActive(false);
        //player.isDead = false;
        //gameIsOver = true;
    }
}
