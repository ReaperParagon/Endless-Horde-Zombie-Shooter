using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultsManager : MonoBehaviour
{
    public static bool playerWon = false;

    private void OnEnable()
    {
        AppEvents.GameComplete += ShowResultsWinLoss;
    }

    private void OnDisable()
    {
        AppEvents.GameComplete -= ShowResultsWinLoss;
    }
    
    private void ShowResultsWinLoss(bool win)
    {
        playerWon = win;

        SceneManager.LoadScene("ResultsScene");
    }
}
