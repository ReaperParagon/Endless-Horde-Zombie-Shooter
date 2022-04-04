using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
    public delegate void OnEquipWeaponEvent(WeaponComponent weaponComponent);

    public static event OnEquipWeaponEvent OnEquipWeapon;

    public static void InvokeOnEquipWeapon(WeaponComponent weaponComponent)
    {
        OnEquipWeapon?.Invoke(weaponComponent);
    }

    public delegate void OnWeaponEquippedEvent(WeaponComponent weaponComponent);

    public static event OnWeaponEquippedEvent OnWeaponEquipped;

    public static void InvokeOnWeaponEquipped(WeaponComponent weaponComponent)
    {
        OnWeaponEquipped?.Invoke(weaponComponent);
    }

    public delegate void OnHealthInitializeEvent(HealthComponent healthComponent);

    public static event OnHealthInitializeEvent OnHealthInitialized;

    public static void InvokeOnHealthInitializeEvent(HealthComponent healthComponent)
    {
        OnHealthInitialized?.Invoke(healthComponent);
    }
}
