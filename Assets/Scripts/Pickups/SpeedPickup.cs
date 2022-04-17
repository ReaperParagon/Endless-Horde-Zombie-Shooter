using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[CreateAssetMenu(fileName = "Speed Pickup", menuName = "Item/SpeedPickup", order = 2)]
public class SpeedPickup : ConsumableItem
{
    public PlayerStats pStats;

    public float speed = 1.5f;
    public float newFOV = 70.0f;

    public float duration = 5.0f;

    public override void UseItem(PlayerController playerController)
    {
        pStats = playerController.GetComponent<PlayerStats>();
        pStats.TemporarySpeedChange(speed, duration);

        ChangeFOV(playerController.GetComponent<CameraController>());

        base.UseItem(playerController);
    }

    public void ChangeFOV(CameraController cameraController)
    {
        cameraController.TemporaryChangeFOV(newFOV, duration);
    }
}
