using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    [SerializeField]
    private float LevelTimer = 300.0f;

    private bool timerDone = false;

    private void OnEnable()
    {
        AppEvents.GameComplete += StopTimer;
    }

    private void OnDisable()
    {
        AppEvents.GameComplete -= StopTimer;
    }

    private void Update()
    {
        if (timerDone) return;

        LevelTimer -= Time.deltaTime;

        if (LevelTimer <= 0.0f)
        {
            LevelTimer = 0.0f;

            // Call Level Completion Event
            AppEvents.InvokeOnGameCompletion(true);
        }

        // Event for Timer Updated (float)
        AppEvents.InvokeOnTimerUpdate(LevelTimer);
    }

    private void StopTimer(bool win)
    {
        timerDone = true;
    }

}
