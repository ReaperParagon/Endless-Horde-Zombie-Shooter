using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippableItem : ItemScript
{
    public bool Equipped
    {
        get => isEquipped;
        set
        {
            isEquipped = value;
            OnEquipStatusChange?.Invoke();
        }
    }

    public delegate void EquipStatusChange();
    public event EquipStatusChange OnEquipStatusChange;

    bool isEquipped = false;

    public override void UseItem(PlayerController playerController)
    {
        Equipped = !Equipped;
    }
}
