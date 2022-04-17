using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Damage Pickup", menuName = "Item/DamagePickup", order = 2)]
public class DamageItem : ConsumableItem
{
    public PlayerStats pStats;

    public float damageMultiplier = 2.0f;
    public float duration = 30.0f;

    public override void UseItem(PlayerController playerController)
    {
        pStats = playerController.GetComponent<PlayerStats>();
        pStats.TemporaryDamageChange(damageMultiplier, duration);

        base.UseItem(playerController);
    }
}
