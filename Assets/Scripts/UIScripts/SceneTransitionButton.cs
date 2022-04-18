using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionButton : MonoBehaviour
{
    public List<GameObject> showObjs = new List<GameObject>();
    public List<GameObject> hideObjs = new List<GameObject>();

    public void ToggleObjects()
    {
        if (showObjs.Count <= 0) return;

        bool isShown = showObjs[0].activeSelf;

        foreach (var item in showObjs)
        {
            item.SetActive(!isShown);
        }

        foreach (var item in hideObjs)
        {
            item.SetActive(isShown);
        }
    }

    public void GoToScene(string goToScene)
    {
        SceneManager.LoadScene(goToScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
