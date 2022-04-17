using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppEvents
{
    public delegate void OnMouseCursorEnable(bool enabled);

    public static event OnMouseCursorEnable MouseCursorEnabled;

    public static void InvokeOnMouseCursorEnable(bool enabled)
    {
        MouseCursorEnabled?.Invoke(enabled);
    }


    public delegate void OnGameCompletion(bool win);

    public static event OnGameCompletion GameComplete;

    public static void InvokeOnGameCompletion(bool win)
    {
        GameComplete?.Invoke(win);
    }


    public delegate void OnTimerUpdate(float timer);

    public static event OnTimerUpdate UpdateTimer;

    public static void InvokeOnTimerUpdate(float timer)
    {
        UpdateTimer?.Invoke(timer);
    }
}
