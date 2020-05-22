using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public interface IMovementController
{
    Tilemap GetBombsTilemap();
    Vector3Int GetCurrentPosition();

    void GetMovementDirection();
    Int32 GetNumberOfBombs(Vector3Int currentPlayerTile);
}