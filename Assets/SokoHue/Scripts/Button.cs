using System;
using UnityEngine;

public class Button : MonoBehaviour
{
    public static event Action<Colour> Press;
    public static event Action<Colour> UnPress;
    private bool Triggered = false;
    private SpriteRenderer _renderer;
    [SerializeField] Colour colour;
    [SerializeField] Sprite upSprite;
    [SerializeField] Sprite downSprite;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger entered");
        if (!Triggered && collision.CompareTag("Pushable"))
        {
            Press?.Invoke(colour);
            Triggered = true;
            _renderer.sprite = downSprite;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Trigger exited");
        if (Triggered && collision.CompareTag("Pushable"))
        {
            UnPress?.Invoke(colour);
            Triggered = false;
            _renderer.sprite = upSprite;
        }
    }
}
