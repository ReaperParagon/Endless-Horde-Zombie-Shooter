using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ammo", menuName = "Item/Ammo", order = 3)]
public class AmmoItem : ConsumableItem
{
    public int ammoAmount = 30;

    public override void UseItem(PlayerController playerController)
    {
        playerController.GetComponent<WeaponHolder>().equippedWeapon.AddAmmo(ammoAmount);

        base.UseItem(playerController);
    }
}
