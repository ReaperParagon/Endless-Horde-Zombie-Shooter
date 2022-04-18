using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWeapon", menuName = "Item/Weapon", order = 2)]
public class WeaponItem : EquippableItem
{
    public WeaponStats weaponStats;

    private WeaponStats tempWeaponStats;

    private GameObject weapon;

    private static WeaponItem equippedWeapon;

    private void Awake()
    {
        tempWeaponStats = weaponStats;
    }

    public override void UseItem(PlayerController playerController)
    {
        if (Equipped)
        {
            // Unequip from inventory
            // And Controller

            tempWeaponStats = playerController.GetComponent<WeaponHolder>().equippedWeapon.weaponStats;

            if (equippedWeapon == this)
                Equipped = false;
        }
        else
        {
            var prevWeapon = equippedWeapon;
            equippedWeapon = this;

            if (prevWeapon != null)
            {
                prevWeapon.UseItem(playerController);
            }

            weapon = Instantiate(itemPrefab);
            weapon.GetComponent<WeaponComponent>().weaponStats = tempWeaponStats;

            PlayerEvents.InvokeOnEquipWeapon(weapon.GetComponent<WeaponComponent>());

            Destroy(weapon);
        }

        base.UseItem(playerController);
    }

    public void RefillAmmo(int ammo)
    {
        weaponStats.totalBullets += ammo;
    }
}
