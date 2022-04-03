using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWeapon", menuName = "Item/Weapon", order = 2)]
public class WeaponItem : EquippableItem
{
    public WeaponStats weaponStats;

    public override void UseItem(PlayerController playerController)
    {
        if (Equipped)
        {
            // Unequip from inventory
            // And Controller
        }
        else
        {
            // Invoke on weapon equipped from player events here
            // Equip weaopn from weapon holder on player controller
        }

        base.UseItem(playerController);
    }
}
