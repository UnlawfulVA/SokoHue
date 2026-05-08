using UnityEngine;

public class ToggleWalls : MonoBehaviour
{
    [SerializeField] Colour wallColour;
    [SerializeField] bool startToggle;

    private Collider2D collider;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        collider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (startToggle)
        {
            ToggleOn();
            Debug.Log(startToggle + "1");
        }
        else
        {
            ToggleOff();
            Debug.Log(startToggle + "2");
        }
    }

    private void OnEnable()
    {
        Button.Press += OnButtonToggle;
        Button.UnPress += OnButtonUntoggle;
    }

    private void OnDisable()
    {
        Button.Press -= OnButtonToggle;
        Button.UnPress -= OnButtonUntoggle;
    }

    private void OnButtonToggle(Colour buttonColour)
    {
        if (wallColour == buttonColour)
        {
            if (startToggle)
            {
                ToggleOff();
                Debug.Log(startToggle + "1");
            }
            else
            {
                ToggleOn();
                Debug.Log(startToggle + "2");
            }
        }
    }

    private void OnButtonUntoggle(Colour buttonColour)
    {
        if (wallColour == buttonColour)
        {
            if (!startToggle)
            {
                ToggleOn();
                Debug.Log(startToggle + "3");
            }
            else
            {
                ToggleOff();
                Debug.Log(startToggle + "4");
            }
        }
    }
    private void ToggleOn()
    {
        collider.enabled = true;
        startToggle = true;
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1.0f);
    }

    private void ToggleOff()
    {
        collider.enabled = false;
        startToggle = false;
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.5f);
    }
}
