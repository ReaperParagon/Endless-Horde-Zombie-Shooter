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

    public InventoryComponent inventory;
    public InventoryCanvas invCanvas;

    public void OnInventory(InputValue value)
    {
        invCanvas.gameObject.SetActive(!invCanvas.gameObject.activeSelf);
    }
}
