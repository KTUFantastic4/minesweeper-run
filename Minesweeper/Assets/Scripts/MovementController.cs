using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;
[RequireComponent(typeof(Rigidbody2D))]
public class MovementController : MonoBehaviour, IMovementController
{
    //Stores input from the PlayerInput
    private Vector2 movementInput;
    private Vector3 direction;

    public Tile water;
    public Tile tower;
    public Tile bomb;
    public Tilemap tilemap;
    public Tilemap up;
    public Tilemap fogOfWar;
    public Tilemap bombs;
    public Tilemap numbers;
    public Tile[] numbers_tile;

    private SpriteRenderer spriteRenderer;
    public Sprite spriteRobo;
    public Sprite health;
    public Sprite sun;
    public Sprite food;
    public Sprite spritePlayer;
    public Vector3Int currentPlayerTile;
    public bool checkPosition = false;

    private Player player;
    private Rigidbody2D rigidbody2D;
    private BombDetection bombDetection;

    public bool isDead = false;
    public bool isWon = false;

    
    

    bool hasMoved;
    public int vision = 1;

    public Text healthDisplay;
    private void Awake()
    {
        player = new Player();
        bombDetection = new BombDetection();
        
    }

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.transform.position = new Vector3(-8, -8.6f, 0);
        player.changePosition(new Vector3(-8, -8.6f, 0));

        
       


        
        //this.GetComponent<SpriteRenderer>().sprite = spritePlayer;
    }

    public void LoadForTesting()
    {

    }

    void Update()
    {
        //For testing
        if (checkPosition)
        {
            currentPlayerTile = bombs.WorldToCell(rigidbody2D.transform.position);
            CheckIfSteppedOnBomb(currentPlayerTile);
            CheckIfWin();
            checkPosition = false;
        }

        if (player.isRobot)
        {
            this.GetComponent<SpriteRenderer>().sprite = spriteRobo;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sprite = spritePlayer;
        }
        //Debug.Log("Player cords: "+ GetComponent<Rigidbody2D>().transform.position);
        //For testing only
        //transform.position = new Vector3Int(-5, -16, 0);
        //rigidbody2D.MovePosition();
        if (!isDead)
        {
            if (movementInput.x == 0)
            {
                hasMoved = false;
            }
            else if (movementInput.x != 0 && !hasMoved)
            {
                hasMoved = true;
                Debug.Log("Player input detected");

                GetMovementDirection();
            }
        }
        healthDisplay.text = player.lives.ToString();
    }

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
        //player.addLive();
        player.isRobot = true;
        Debug.Log("Robot item used");
    }

    public void HealthItemUsed()
    {
        this.GetComponent<SpriteRenderer>().sprite = health;
        player.addLive();
    }

    public void SunItemUsed()
    {
        currentPlayerTile = fogOfWar.WorldToCell(transform.position);
        if (currentPlayerTile.y % 2 == 0)
        {
            UpdateFogOfWar(currentPlayerTile + new Vector3Int(0 - 1, 0 - 1, 0));
            UpdateFogOfWar(currentPlayerTile + new Vector3Int(0, 0 - 1, 0));
            UpdateFogOfWar(currentPlayerTile + new Vector3Int(0 + 1, 0, 0));
            UpdateFogOfWar(currentPlayerTile + new Vector3Int(0, 0 + 1, 0));
            UpdateFogOfWar(currentPlayerTile + new Vector3Int(0 - 1, 0 + 1, 0));
            UpdateFogOfWar(currentPlayerTile + new Vector3Int(0 - 1, 0, 0));

            CheckIfSteppedOnBomb(currentPlayerTile + new Vector3Int(0 - 1, 0 - 1, 0),true);
            CheckIfSteppedOnBomb(currentPlayerTile + new Vector3Int(0, 0 - 1, 0),true);
            CheckIfSteppedOnBomb(currentPlayerTile + new Vector3Int(0 + 1, 0, 0),true);
            CheckIfSteppedOnBomb(currentPlayerTile + new Vector3Int(0, 0 + 1, 0),true);
            CheckIfSteppedOnBomb(currentPlayerTile + new Vector3Int(0 - 1, 0 + 1, 0),true);
            CheckIfSteppedOnBomb(currentPlayerTile + new Vector3Int(0 - 1, 0, 0),true);
        }
        else
        {
            UpdateFogOfWar(currentPlayerTile + new Vector3Int(0, 0 - 1, 0));
            UpdateFogOfWar(currentPlayerTile + new Vector3Int(0 + 1, 0 - 1, 0));
            UpdateFogOfWar(currentPlayerTile + new Vector3Int(0 + 1, 0, 0));
            UpdateFogOfWar(currentPlayerTile + new Vector3Int(0 + 1, 0 + 1, 0));
            UpdateFogOfWar(currentPlayerTile + new Vector3Int(0, 0 + 1, 0));
            UpdateFogOfWar(currentPlayerTile + new Vector3Int(0 - 1, 0, 0));

            CheckIfSteppedOnBomb(currentPlayerTile + new Vector3Int(0, 0 - 1, 0),true);
            CheckIfSteppedOnBomb(currentPlayerTile + new Vector3Int(0 + 1, 0 - 1, 0),true);
            CheckIfSteppedOnBomb(currentPlayerTile + new Vector3Int(0 + 1, 0, 0),true);
            CheckIfSteppedOnBomb(currentPlayerTile + new Vector3Int(0 + 1, 0 + 1, 0),true);
            CheckIfSteppedOnBomb(currentPlayerTile + new Vector3Int(0, 0 + 1, 0),true);
            CheckIfSteppedOnBomb(currentPlayerTile + new Vector3Int(0 - 1, 0, 0),true);
        }
    }

    public void FoodItemUsed()
    {
        this.GetComponent<SpriteRenderer>().sprite = food;
        player.addLive();
    }

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
                currentPlayerTile = fogOfWar.WorldToCell(transform.position);
                UpdateFogOfWar(currentPlayerTile);
            }
            currentPlayerTile = bombs.WorldToCell(rigidbody2D.transform.position);
            CheckIfSteppedOnBomb(currentPlayerTile);
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
                currentPlayerTile = fogOfWar.WorldToCell(transform.position);
                UpdateFogOfWar(currentPlayerTile);
            }
            currentPlayerTile = bombs.WorldToCell(rigidbody2D.transform.position);
            CheckIfSteppedOnBomb(currentPlayerTile);
            UpdateNumbers();
        }
        CheckIfWin();

    }

    public void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
        Debug.Log("On move value: " + movementInput);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.position -= direction;
        Debug.Log("Collision");
    }

    //Check if player reached finish
    private void CheckIfWin()
    {
        if (up.GetTile(up.WorldToCell(transform.position)) == tower)
        {
            player.changeWinning(true);
            //Print to console
            Debug.Log("Winner winner chicked dinner!");
            //Show mines
            bombs.GetComponent<TilemapRenderer>().sortingOrder = (int)(GetComponent<Renderer>().transform.position.y + 1000);
            isWon = true;           
        }
    }
    //Check if player steped on mine
    private bool CheckIfSteppedOnBomb(Vector3Int currentPlayerTile, bool item = false)
    {
        //Vector3Int currentPlayerTile = bombs.WorldToCell(rigidbody2D.transform.position);

        //if (bombs.GetTile(currentPlayerTile) != null && !isDead)
        if (bombDetection.HandlePlayerInteractionWithBombs(bombs, currentPlayerTile) && !isDead)
        {
            if (item)
            {
                tilemap.SetTile(currentPlayerTile + new Vector3Int(0, 0, 0), bomb);
            }else if (player.isRobot)
            {
                if (player.isRobot)
                {
                    player.isRobot = false;
                    this.GetComponent<SpriteRenderer>().sprite = spritePlayer;
                }
            }
            else if (player.lives > 1)
            {
                player.subtractLive();
            }else{
                //Show mines
                bombs.GetComponent<TilemapRenderer>().sortingOrder = (int)(GetComponent<Renderer>().transform.position.y + 1000);
                player.subtractLive();
                //Check if not won  
                if (!isWon)
                {
                    isDead = true;
                    player.changeDead(isDead);

                    //Print to console  
                    Debug.Log(bombs.GetTile(bombs.WorldToCell(transform.position)));
                    Debug.Log("BOOOOM!" + currentPlayerTile);
                    return true;
                }
            }
        }
        return false;
    }

    //Set numbers to tiles
    private void UpdateNumbers()
    {
        currentPlayerTile = bombs.WorldToCell(transform.position);

        int bombsNumber = GetNumberOfBombs(currentPlayerTile);
        if (bombsNumber > 0)
        {
            numbers.SetTile(currentPlayerTile, numbers_tile[bombsNumber - 1]);
        }else if(bombsNumber == -1 && player.lives>=1)
        {
            tilemap.SetTile(currentPlayerTile + new Vector3Int(0, 0, 0), bomb);
        }
    }
    
    private void UpdateFogOfWar(Vector3Int currentPlayerTile)
    {
        //Vector3Int currentPlayerTile = fogOfWar.WorldToCell(transform.position);
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
        if (bombs.GetTile(currentPlayerTile) != null)
        {
            return -1;
        }
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
