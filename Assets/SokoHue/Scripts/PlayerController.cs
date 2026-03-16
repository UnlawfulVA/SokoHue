using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Tilemap groundTilemap;
    [SerializeField] private Tilemap collisionTilemap;
    [SerializeField] private Tilemap buttonTilemap;
    [SerializeField] private Tilemap pushableTilemap;
    private Controls controls;

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
        controls.Gameplay.Movement.started += ctx => Move(ctx.ReadValue<Vector2>());
    }
    private void Move(Vector2 direction)
    {
        if (CanMove(direction) && direction.x != 0)
            transform.position += new Vector3(direction.x, 0, 0);
        else if (CanMove(direction) && direction.y != 0)
            transform.position += new Vector3(0, direction.y, 0);
        else direction = Vector2.zero;
    }

    private bool CanMove(Vector2 direction) 
    {
        Vector3Int gridPosition = groundTilemap.WorldToCell(transform.position + (Vector3)direction.normalized);
        if (!groundTilemap.HasTile(gridPosition) || collisionTilemap.HasTile(gridPosition)) 
            return false;
        return true;
    }
}
