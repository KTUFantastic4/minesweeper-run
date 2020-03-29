﻿using System.Collections;
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

            if (tilemap.GetTile(tilemap.WorldToCell(transform.position + direction)) != null && tilemap.GetTile(tilemap.WorldToCell(transform.position + direction)) != water)
            {

                transform.position += direction;
                UpdateFogOfWar();
            }

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

            if (tilemap.GetTile(tilemap.WorldToCell(transform.position + direction)) != null && tilemap.GetTile(tilemap.WorldToCell(transform.position + direction)) != water)
            {

                transform.position += direction;
                UpdateFogOfWar();
            }

        }
        if (bombs.GetTile(bombs.WorldToCell(transform.position)) != null)
        {
            Debug.Log(bombs.GetTile(bombs.WorldToCell(transform.position)));
            Debug.Log("BOOOOM!");
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

    public int vision = 1;

    void UpdateFogOfWar()
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

    }
}
