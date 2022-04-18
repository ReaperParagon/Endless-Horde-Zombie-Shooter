using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Damage Pickup", menuName = "Item/DamagePickup", order = 2)]
public class DamageItem : ConsumableItem
{
    public PlayerStats pStats;

    public float newFOV = 60.0f;
    public float damageMultiplier = 2.0f;
    public float duration = 30.0f;

    public override void UseItem(PlayerController playerController)
    {
        pStats = playerController.GetComponent<PlayerStats>();
        pStats.TemporaryDamageChange(damageMultiplier, duration);

        playerController.GetComponent<CameraController>().TemporaryChangeFOV(newFOV, duration);

        base.UseItem(playerController);
    }
}
