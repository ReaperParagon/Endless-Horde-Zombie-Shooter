using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public PlayerInput playerInput;

    public void TogglePaused()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        playerInput.enabled = !playerInput.enabled;

        AppEvents.InvokeOnMouseCursorEnable(pauseMenu.activeSelf);

        if (Time.timeScale > 0.5f)
            Time.timeScale = 0.0f;
        else
            Time.timeScale = 1.0f;
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    /// Input System ///
    
    public void OnPause(InputValue input)
    {
        TogglePaused();
    }

}
