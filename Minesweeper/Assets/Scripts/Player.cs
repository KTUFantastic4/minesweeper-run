using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public int lives { get; set; }
    public bool hasWon { get; set; }
    public bool isDead { get; set; }
    public Vector3 position { get; private set; }

    public Player(int lives = 1, bool hasWon = false, bool isDead = false)
    {
        this.lives = lives;
        this.hasWon = hasWon;
        this.isDead = isDead;

        Debug.Log("Player created");
    }
    
    public void changePosition(Vector3 newPos)
    {
        this.position = newPos;
        Debug.Log("Position changed to: "+ position);
    }

    public void changeWinning(bool hasWon)
    {
        this.hasWon = hasWon;
        Debug.Log("Player hasWon changed");
    }

    public void changeDead(bool dead)
    {
        this.isDead = dead;
        Debug.Log("Player isDead changed");
    }
}
