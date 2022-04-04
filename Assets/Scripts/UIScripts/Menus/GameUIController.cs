using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIController : MonoBehaviour
{

    [SerializeField] private GameHUDWidget GameCanvas;
    //[SerializeField] private GameHUDWidget PauseCanvas;
    [SerializeField] private GameHUDWidget InventoryCanvas;

    private GameHUDWidget ActiveWidget;

    private void Start()
    {
        DisableAllMenus();
        EnableGameMenu();
    }

    public void EnablePauseMenu()
    {
        if (ActiveWidget) ActiveWidget.DisableWidget();
       
        //ActiveWidget = PauseCanvas;
        ActiveWidget.EnableWidget();
    }

    public void EnableGameMenu()
    {
        if (ActiveWidget) ActiveWidget.DisableWidget();

        ActiveWidget = GameCanvas;
        ActiveWidget.EnableWidget();
    }

    public void EnableInventoryMenu()
    {
        ActiveWidget = InventoryCanvas;
        ActiveWidget.EnableWidget();
    }

    /// <summary>
    /// Toggle's the inventory visibility
    /// </summary>
    /// <returns>If the inventory is now open</returns>
    public bool ToggleInventoryMenu()
    {
        if (InventoryCanvas.gameObject.activeInHierarchy)
        {
            EnableGameMenu();
            return false;
        }
        else
        {
            EnableInventoryMenu();
            return true;
        }
    }

    public void DisableAllMenus()
    {
        GameCanvas.DisableWidget();
        //PauseCanvas.DisableWidget();
        InventoryCanvas.DisableWidget();
    }
}

public abstract class GameHUDWidget : MonoBehaviour
{
    public virtual void EnableWidget() 
    {
        gameObject.SetActive(true);
    }
    public virtual void DisableWidget()
    {
        gameObject.SetActive(false);
    }

}