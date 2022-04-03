using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Consumable", menuName = "Item/Consumable", order = 1)]
public class ConsumableItem : ItemScript
{
    public int effect = 1;

    public override void UseItem(PlayerController playerController)
    {
        // Check to seee if player is at max health, returh 
        // heal player with potion

        SetAmount(amountValue - 1);
        if (amountValue <= 0)
        {
            DeleteItem(playerController);
        }
    }
}
