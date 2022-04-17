using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Potion", menuName = "Item/Potion", order = 3)]
public class PotionItem : ConsumableItem
{
    public float health;

    public override void UseItem(PlayerController playerController)
    {
        playerController.GetComponent<PlayerHealthComponent>().Heal(health);

        base.UseItem(playerController);
    }
}
