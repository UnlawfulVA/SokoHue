using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Tilemap groundTilemap;
    [SerializeField] private Tilemap collisionTilemap;
    private Controls controls;
    private Rigidbody2D rb2d;

    public static event Action Win;
    private void Awake()
    {
        controls = new Controls();
    }
    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        controls.Gameplay.Movement.started += ctx => AttemptMove(ctx.ReadValue<Vector2>());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Win"))
        {
            Debug.Log("Win");
            Win?.Invoke();
        }
    }

    private void AttemptMove(Vector2 inputDirection)
    {
        Vector3 intendedDirection;
        if (inputDirection.x != 0)
            intendedDirection = new Vector3(inputDirection.x, 0, 0);
        else if (inputDirection.y != 0)
            intendedDirection = new Vector3(0, inputDirection.y, 0);
        else
            intendedDirection = Vector2.zero;

        // Calculate the target position based on the player's current position and the intended movement direction
        Vector3 targetPos = transform.position + intendedDirection;

        // Check if the movement in the intended direction is valid
        if (CheckTileInDir(intendedDirection))
        {
            // Attempt to get a pushable object at the target position
            Pushable pushable = GetPushableAtPosition(targetPos);
            if (pushable != null)
            {
                // If a pushable object is found, try to push it in the intended direction
                if (pushable.TryPush(intendedDirection))
                {
                    // Move the player to the target position after a successful push
                    transform.position = targetPos;
                }
            }
            else
            {
                // If no pushable object is found, move the player to the target position directly
                transform.position = targetPos;
            }
        }
    }

    // Checks if there is a tile in the specified direction
    private bool CheckTileInDir(Vector2 direction)
    {
        // Convert the player's world position plus the direction to a grid position
        Vector3Int gridPosition = groundTilemap.WorldToCell(transform.position + (Vector3)direction.normalized);

        // Check if there is no tile in the groundTilemap or if there is a tile in the collisionTilemap
        if (!groundTilemap.HasTile(gridPosition) || collisionTilemap.HasTile(gridPosition))
            return false; // Return false if movement is blocked

        return true; // Return true if movement is allowed
    }

    // Gets a pushable object at the specified world position
    private Pushable GetPushableAtPosition(Vector3 worldPosition)
    {
        // Check for any colliders at the specified world position
        Collider2D hit = Physics2D.OverlapPoint(worldPosition);

        // If a collider is found, attempt to get the Pushable component
        if (hit != null)
            return hit.GetComponent<Pushable>(); // Return the Pushable component if it exists

        return null; // Return null if no pushable object is found
    }
}
