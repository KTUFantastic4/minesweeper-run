using UnityEngine;
using UnityEngine.Tilemaps;
public class BombDetection
{
    public bool HandlePlayerInteractionWithBombs(Tilemap bombs, Vector3Int pos)
    {
        if (bombs.GetTile(pos) != null)
        {
                return true;
        }
        return false;
    }
}