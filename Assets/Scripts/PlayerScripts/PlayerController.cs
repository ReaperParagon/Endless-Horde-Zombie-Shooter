using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public bool isFiring;
    public bool isReloading;
    public bool isJumping;
    public bool isRunning;
    public bool isAiming;

    public bool isInventoryOpen = false;

    public InventoryComponent inventory;
    public GameUIController uiController;

    public void OnInventory(InputValue value)
    {
        isInventoryOpen = uiController.ToggleInventoryMenu();
    }
}
