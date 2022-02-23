using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickupScript : MonoBehaviour
{
    protected PlayerStats currentPlayer;

    public abstract void UsePickup(PlayerStats player);
}
