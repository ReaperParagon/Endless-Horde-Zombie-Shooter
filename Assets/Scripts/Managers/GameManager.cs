using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

    public bool cursorActive = true;

    void EnableCursor(bool enable)
    {
        if (enable)
        {
            cursorActive = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            cursorActive = false;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void OnEnable()
    {
        AppEvents.MouseCursorEnabled += EnableCursor;

        SceneManager.sceneLoaded += ResetTime;
    }

    private void OnDisable()
    {
        AppEvents.MouseCursorEnabled -= EnableCursor;

        SceneManager.sceneLoaded -= ResetTime;
    }

    private void ResetTime(Scene _, LoadSceneMode __)
    {
        Time.timeScale = 1.0f;

        print("Scene Loaded...");
    }
}
