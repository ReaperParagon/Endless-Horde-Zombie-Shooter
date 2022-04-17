using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Consumable", menuName = "Item/Consumable", order = 1)]
public class ConsumableItem : ItemScript
{
    public override void UseItem(PlayerController playerController)
    {
        SetAmount(amountValue - 1);
        if (amountValue <= 0)
        {
            DeleteItem(playerController);
        }
    }
}
