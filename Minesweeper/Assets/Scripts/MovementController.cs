using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class MovementController : MonoBehaviour
{
    //public float health;
    public Text healthDisplay;
    //Stores input from the PlayerInput
    private Vector2 movementInput;
    private Vector3 direction;

    public Tile water;
    public Tile tower;
    public Tilemap tilemap;
    public Tilemap up;
    public Tilemap fogOfWar;
    public Tilemap bombs;
    public Tilemap numbers;
    public Tile[] numbers_tile;

<<<<<<< Updated upstream
=======
    private SpriteRenderer spriteRenderer;
    public Sprite spriteRobo;
    public Sprite health;
    public Sprite sun;
    public Sprite spritePlayer;
    public bool checkPosition = false;

    private Player player;
    private Rigidbody2D rigidbody2D;
    private BombDetection bombDetection;

>>>>>>> Stashed changes
    public bool isDead = false;

    bool hasMoved;

    void Update()
    {
<<<<<<< Updated upstream

        if(!isDead)
=======
        healthDisplay.text = player.lives.ToString();
        //For testing
        if (checkPosition)
        {
            CheckIfSteppedOnBomb();
            CheckIfWin();
            checkPosition = false;
        }
        
        //Debug.Log("Player cords: "+ GetComponent<Rigidbody2D>().transform.position);
        //For testing only
        //transform.position = new Vector3Int(-5, -16, 0);
        //rigidbody2D.MovePosition();
        if (!isDead)
>>>>>>> Stashed changes
        {
            if (movementInput.x == 0)
            {
                hasMoved = false;
            }
            else if (movementInput.x != 0 && !hasMoved)
            {
                hasMoved = true;

                GetMovementDirection();
            }
        }

    }

<<<<<<< Updated upstream
=======
    public Tilemap GetBombsTilemap()
    {
        return bombs;
    }

    public Vector3Int GetCurrentPosition()
    {
        return bombs.WorldToCell(transform.position);
    }

    public void RobotItemUsed()
    {
        this.GetComponent<SpriteRenderer>().sprite = spriteRobo;
        player.addLive();
        player.isRobot = true;
        Debug.Log("Robot item used");
    }

    public void HealthItemUsed()
    {
        this.GetComponent<SpriteRenderer>().sprite = health;
        player.addLive();
        //player.isRobot = true;
        //Debug.Log("Robot item used");
    }

    public void SunItemUsed()
    {
        this.GetComponent<SpriteRenderer>().sprite = sun;
        player.addLive();
        //player.isRobot = true;
        //Debug.Log("Robot item used");
    }
>>>>>>> Stashed changes
    public void GetMovementDirection()
    {
        if (movementInput.x < 0)
        {
            if (movementInput.y > 0)
            {
                direction = new Vector3(-0.5f, 0.4885f);
            }
            else if (movementInput.y < 0)
            {
                direction = new Vector3(-0.5f, -0.4885f);
            }
            else
            {
                direction = new Vector3(-1, 0, 0);
            }
            //Check if trying to go on restricted tile
            if (up.GetTile(up.WorldToCell(transform.position + direction)) == tower ||
                (tilemap.GetTile(tilemap.WorldToCell(transform.position + direction)) != null &&
                tilemap.GetTile(tilemap.WorldToCell(transform.position + direction)) != water &&
                up.GetTile(up.WorldToCell(transform.position + direction)) == null))
            {

                transform.position += direction;
                UpdateFogOfWar();
            }
            CheckIfSteppedOnBomb();
            UpdateNumbers();

        }
        else if (movementInput.x > 0)
        {
            if (movementInput.y > 0)
            {
                direction = new Vector3(0.5f, 0.4885f);
            }
            else if (movementInput.y < 0)
            {
                direction = new Vector3(0.5f, -0.4885f);
            }
            else
            {
                direction = new Vector3(1, 0, 0);
            }
            //Check if trying to go on restricted tile
            if (up.GetTile(up.WorldToCell(transform.position + direction)) == tower ||
                (tilemap.GetTile(tilemap.WorldToCell(transform.position + direction)) != null &&
                tilemap.GetTile(tilemap.WorldToCell(transform.position + direction)) != water &&
                up.GetTile(up.WorldToCell(transform.position + direction)) == null))
            {

                transform.position += direction;
                UpdateFogOfWar();
            }
            CheckIfWin();
            CheckIfSteppedOnBomb();
            UpdateNumbers();
        }

    }

    public void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.position -= direction;
    }

    //Check if player reached finish
    private void CheckIfWin()
    {
        if (up.GetTile(up.WorldToCell(transform.position)) == tower)
        {
            //Print to console
            Debug.Log("Winner winner chicked dinner!");
        }
    }
    //Check if player steped on mine
<<<<<<< Updated upstream
    private void CheckIfSteppedOnBomb()
=======
    public bool CheckIfSteppedOnBomb()
>>>>>>> Stashed changes
    {
        if (bombs.GetTile(bombs.WorldToCell(transform.position)) != null && !isDead)
        {
            //Show mines
            bombs.GetComponent<TilemapRenderer>().sortingOrder = (int)(GetComponent<Renderer>().transform.position.y + 1000);

            //Print to console         
            
            isDead = true;
            
            Debug.Log(bombs.GetTile(bombs.WorldToCell(transform.position)));
            Debug.Log("BOOOOM!");
            
        }
    }

    //Set numbers to tiles
    private void UpdateNumbers()
    {
        Vector3Int currentPlayerTile = bombs.WorldToCell(transform.position);

        int bombsNumber = GetNumberOfBombs(currentPlayerTile);
        if (bombsNumber > 0)
            numbers.SetTile(currentPlayerTile, numbers_tile[bombsNumber - 1]);
    }


    public int vision = 1;

    /*   void UpdateFogOfWar()
       {
           Vector3Int currentPlayerTile = fogOfWar.WorldToCell(transform.position);

           //Clear the surrounding tiles
           for (int x = -vision; x <= vision; x++)
           {
               for (int y = -vision; y <= vision; y++)
               {
                   fogOfWar.SetTile(currentPlayerTile + new Vector3Int(x, y, 0), null);
               }

           }

       }*/
    private void UpdateFogOfWar()
    {
        Vector3Int currentPlayerTile = fogOfWar.WorldToCell(transform.position);
        fogOfWar.SetTile(currentPlayerTile, null);
        if (currentPlayerTile.y % 2 == 0)
        {
            fogOfWar.SetTile(currentPlayerTile + new Vector3Int(0 - 1, 0 - 1, 0), null);
            fogOfWar.SetTile(currentPlayerTile + new Vector3Int(0, 0 - 1, 0), null);
            fogOfWar.SetTile(currentPlayerTile + new Vector3Int(0 + 1, 0, 0), null);
            fogOfWar.SetTile(currentPlayerTile + new Vector3Int(0, 0 + 1, 0), null);
            fogOfWar.SetTile(currentPlayerTile + new Vector3Int(0 - 1, 0 + 1, 0), null);
            fogOfWar.SetTile(currentPlayerTile + new Vector3Int(0 - 1, 0, 0), null);
        }
        else
        {
            fogOfWar.SetTile(currentPlayerTile + new Vector3Int(0, 0 - 1, 0), null);
            fogOfWar.SetTile(currentPlayerTile + new Vector3Int(0 + 1, 0 - 1, 0), null);
            fogOfWar.SetTile(currentPlayerTile + new Vector3Int(0 + 1, 0, 0), null);
            fogOfWar.SetTile(currentPlayerTile + new Vector3Int(0 + 1, 0 + 1, 0), null);
            fogOfWar.SetTile(currentPlayerTile + new Vector3Int(0 , 0 + 1, 0), null);
            fogOfWar.SetTile(currentPlayerTile + new Vector3Int(0 - 1, 0, 0), null);

        }

    }

    public int GetNumberOfBombs(Vector3Int currentPlayerTile)
    {
        int bombsNumber = 0;
        if (currentPlayerTile.y % 2 == 0)
        {
            if (bombs.GetTile(currentPlayerTile + new Vector3Int(0 - 1, 0 - 1, 0)) != null) bombsNumber++;
            if (bombs.GetTile(currentPlayerTile + new Vector3Int(0, 0 - 1, 0)) != null) bombsNumber++;
            if (bombs.GetTile(currentPlayerTile + new Vector3Int(0 + 1, 0, 0)) != null) bombsNumber++;
            if (bombs.GetTile(currentPlayerTile + new Vector3Int(0, 0 + 1, 0)) != null) bombsNumber++;
            if (bombs.GetTile(currentPlayerTile + new Vector3Int(0 - 1, 0 + 1, 0)) != null) bombsNumber++;
            if (bombs.GetTile(currentPlayerTile + new Vector3Int(0 - 1, 0, 0)) != null) bombsNumber++;
        }
        else
        {
            if (bombs.GetTile(currentPlayerTile + new Vector3Int(0, 0 - 1, 0)) != null) bombsNumber++;
            if (bombs.GetTile(currentPlayerTile + new Vector3Int(0 + 1, 0 - 1, 0)) != null) bombsNumber++;
            if (bombs.GetTile(currentPlayerTile + new Vector3Int(0 + 1, 0, 0)) != null) bombsNumber++;
            if (bombs.GetTile(currentPlayerTile + new Vector3Int(0 + 1, 0 + 1, 0)) != null) bombsNumber++;
            if (bombs.GetTile(currentPlayerTile + new Vector3Int(0, 0 + 1, 0)) != null) bombsNumber++;
            if (bombs.GetTile(currentPlayerTile + new Vector3Int(0 - 1, 0, 0)) != null) bombsNumber++;
        }
        return bombsNumber;
    }
}