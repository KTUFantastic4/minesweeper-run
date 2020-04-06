using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class MovementController : MonoBehaviour
{
    //Stores input from the PlayerInput
    private Vector2 movementInput;

    private Vector3 direction;

    public Tile water;
    public Tilemap tilemap;
    public Tilemap fogOfWar;
    public Tilemap bombs;
    public Tilemap numbers;
    public Tile[] numbers_tile;

    bool hasMoved;

    void Update()
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

    public void GetMovementDirection()
    {
        if (movementInput.x < 0)
        {
            if (movementInput.y > 0)
            {
                direction = new Vector3(-0.5f, 0.5f);
            }
            else if (movementInput.y < 0)
            {
                direction = new Vector3(-0.5f, -0.5f);
            }
            else
            {
                direction = new Vector3(-1, 0, 0);
            }
            //Check if trying to go on restricted tile
            if (tilemap.GetTile(tilemap.WorldToCell(transform.position + direction)) != null && tilemap.GetTile(tilemap.WorldToCell(transform.position + direction)) != water)
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
                direction = new Vector3(0.5f, 0.5f);
            }
            else if (movementInput.y < 0)
            {
                direction = new Vector3(0.5f, -0.5f);
            }
            else
            {
                direction = new Vector3(1, 0, 0);
            }
            //Check if trying to go on restricted tile
            if (tilemap.GetTile(tilemap.WorldToCell(transform.position + direction)) != null && tilemap.GetTile(tilemap.WorldToCell(transform.position + direction)) != water)
            {

                transform.position += direction;
                UpdateFogOfWar();
            }
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

    private void CheckIfSteppedOnBomb()
    {
        if (bombs.GetTile(bombs.WorldToCell(transform.position)) != null)
        {
            //Show mines
            bombs.GetComponent<TilemapRenderer>().sortingOrder = (int)(GetComponent<Renderer>().transform.position.y + 1000);
            
            //Print to console
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

    private int GetNumberOfBombs(Vector3Int currentPlayerTile)
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