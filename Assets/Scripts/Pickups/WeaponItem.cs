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
            GameObject weapon = Instantiate(itemPrefab);
            weapon.GetComponent<WeaponComponent>().weaponStats = weaponStats;

            PlayerEvents.InvokeOnEquipWeapon(weapon.GetComponent<WeaponComponent>());
        }

        base.UseItem(playerController);
    }

    public void RefillAmmo(int ammo)
    {
        weaponStats.totalBullets += ammo;
    }
}
