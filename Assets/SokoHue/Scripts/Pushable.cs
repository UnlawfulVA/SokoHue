using UnityEngine;
using UnityEngine.Tilemaps;

public class Pushable : MonoBehaviour
{
    [SerializeField] private Tilemap groundTilemap;
    [SerializeField] private Tilemap collisionTilemap;
    private Controls controls;
    
    private void AttemptMove(Vector2 inputDirection)
    {
        // get intended direction
        Vector3 intendedDirection;
        if (inputDirection.x != 0)
            intendedDirection = new Vector3(inputDirection.x, 0, 0);
        else if (inputDirection.y != 0)
            intendedDirection = new Vector3(0, inputDirection.y, 0);
        else intendedDirection = Vector2.zero;

        // check if tile in direction
        if (CheckTileInDir(intendedDirection))
        {

        }
        // check for pushable
        // move

    }

    private bool CheckTileInDir(Vector2 direction)
    {
        Vector3Int gridPosition = groundTilemap.WorldToCell(transform.position + (Vector3)direction.normalized);
        if (!groundTilemap.HasTile(gridPosition) || collisionTilemap.HasTile(gridPosition))
            return false;
        return true;
    }
    private bool CheckIfPushable(bool tileInDir)
    {

    }
}
