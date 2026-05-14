using UnityEngine;
using UnityEngine.Tilemaps;

public class Pushable : MonoBehaviour
{
    [SerializeField] private Tilemap groundTilemap;
    [SerializeField] private Tilemap collisionTilemap;

    private Rigidbody2D rb2d;
    [SerializeField] private LayerMask wallLayers;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    private Pushable GetPushableAtPosition(Vector3 worldPosition)
    {
        Collider2D hit = Physics2D.OverlapPoint(worldPosition);
        if (hit != null)
            return hit.GetComponent<Pushable>();
        return null;
    }

    public bool TryPush(Vector2 direction)
    {
        Vector3 targetPos = transform.position + (Vector3)direction;
        // Check if tile is walkable
        Vector3Int gridPos = groundTilemap.WorldToCell(targetPos);

        bool wallInDir = Physics2D.Raycast(transform.position, direction, 1.0f, wallLayers);
        if (!groundTilemap.HasTile(gridPos) || collisionTilemap.HasTile(gridPos) || wallInDir)
            return false;

        // Check for another pushable
        Pushable nextPushable = GetPushableAtPosition(targetPos);
        if (nextPushable != null)
        {
            // Recursively try to push the next one
            if (!nextPushable.TryPush(direction))
                return false;
        }

        // Move this pushable
        transform.position = targetPos;
        return true;
    }
}
