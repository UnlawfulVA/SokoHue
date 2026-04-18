using System;
using UnityEngine;

public class Button : MonoBehaviour
{
    public static event Action Press;
    public static event Action UnPress;
    private bool Triggered = false;

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (!Triggered && collision.CompareTag("Pushable"))
        {
            Press?.Invoke();
            Triggered = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (Triggered && collision.CompareTag("Pushable"))
        {
            UnPress?.Invoke();
            Triggered = false;
        }
    }
}
