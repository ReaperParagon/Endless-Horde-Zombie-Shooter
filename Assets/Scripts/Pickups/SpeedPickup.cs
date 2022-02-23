using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SpeedPickup : PickupScript
{
    public float speed = 1.5f;
    public float newFOV = 70.0f;

    public override void UsePickup(PlayerStats player)
    {
        currentPlayer = player;

        currentPlayer.speedMultiplier = speed;
    }

    public void ChangeFOV(CameraController cameraController)
    {
        cameraController.GoToFOV(newFOV);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UsePickup(other.GetComponent<PlayerStats>());
            ChangeFOV(other.GetComponent<CameraController>());

            gameObject.SetActive(false);
        }
    }
}
