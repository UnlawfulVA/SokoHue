using NUnit.Framework;
using System.Threading;
using UnityEditor.SearchService;
using UnityEngine;
using System.Collections.Generic;
public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> buttons = new List<GameObject>();
    private int countButtons;
    private int countEvents;
    private void Start()
    {
       countButtons = buttons.Count;
    }
    private void OnEnable()
    {
        PlayerController.Win += OnWin;
        Button.Press += OnPress;
        Button.UnPress += OnUnPress;
    }
    
    private void OnDisable()
    {
        PlayerController.Win -= OnWin;
        Button.Press -= OnPress;
        Button.UnPress -= OnUnPress;
    }

    private void OnPress()
    {
        countEvents++;
    }
    private void OnUnPress()
    {
        countEvents--;
    }
    private void OnWin()
    {
        if (countButtons == countEvents)
        {
            Debug.Log("Winnar");
        }
    }
}
