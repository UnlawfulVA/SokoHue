using System;
using UnityEngine;

public class Button : MonoBehaviour
{
    public static event Action<Colour> Press;
    public static event Action<Colour> UnPress;
    private bool Triggered = false;
    [SerializeField] Colour colour;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger entered");
        if (!Triggered && collision.CompareTag("Pushable"))
        {
            Press?.Invoke(colour);
            Triggered = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Trigger exited");
        if (Triggered && collision.CompareTag("Pushable"))
        {
            UnPress?.Invoke(colour);
            Triggered = false;
        }
    }
}
