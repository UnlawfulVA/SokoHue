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
    }
    
    private void OnDisable()
    {
        PlayerController.Win -= OnWin;
    }

    
    private void OnWin()
    {
        Debug.Log("Winnar");
        SceneManager.LoadScene(levelIndex + 1);
    }
}
