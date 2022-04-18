using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultsDisplayer : MonoBehaviour
{
    public TextMeshProUGUI resultsText;

    private void Awake()
    {
        AppEvents.InvokeOnMouseCursorEnable(true);

        resultsText.text = ResultsManager.playerWon ? "You Survived!" : "You Were Defeated...";
    }
}
