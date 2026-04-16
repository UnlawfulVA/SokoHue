using System.Threading;
using UnityEditor.SearchService;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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
        Debug.Log("boobs");
    }
}
