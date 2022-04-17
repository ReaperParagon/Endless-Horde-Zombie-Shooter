using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI timerText;

    private void OnEnable()
    {
        AppEvents.UpdateTimer += UpdateTimerUI;
    }

    private void OnDisable()
    {
        AppEvents.UpdateTimer -= UpdateTimerUI;
    }
    
    private void UpdateTimerUI(float timer)
    {
        timerText.text = "Survive For: " + timer.ToString("00.00") + "s";
    }
}
