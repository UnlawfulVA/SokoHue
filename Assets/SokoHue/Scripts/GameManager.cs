using NUnit.Framework;
using System.Threading;
using UnityEditor.SearchService;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> buttons = new List<GameObject>();
    private int countButtons;
    private int countEvents;
    [SerializeField] private int levelIndex;
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
        Debug.Log($"Button Pressed - current pressed = {countEvents}");
    }
    private void OnUnPress()
    {
        countEvents--;
        Debug.Log($"Button Pressed - current pressed = {countEvents}");
    }
    private void OnWin()
    {
        if (countButtons == countEvents)
        {
            Debug.Log("Winnar");
            SceneManager.LoadScene(levelIndex);
        }
    }
}
