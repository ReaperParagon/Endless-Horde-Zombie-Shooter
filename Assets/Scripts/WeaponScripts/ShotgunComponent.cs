using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunComponent : WeaponComponent
{
    public Vector2Int spreadRange = new Vector2Int();

    protected override void FireWeapon()
    {
        Vector3 hitLocation;

        if (weaponStats.bulletsInClip > 0 && !isReloading && !weaponHolder.playerController.isRunning)
        {
            base.FireWeapon();
            if (firingEffect)
            {
                firingEffect.Play();
            }

            for (int i = 0; i < weaponStats.bulletsPerShot; i++)
            {
                int xSpread = Random.Range(-spreadRange.x, spreadRange.x);
                int ySpread = Random.Range(-spreadRange.y, spreadRange.y);

                Ray screenRay = mainCamera.ScreenPointToRay(new Vector3((Screen.width / 2) + xSpread, (Screen.height / 2) + ySpread, 0));
                if (!Physics.Raycast(screenRay, out RaycastHit hit, weaponStats.fireDistance, weaponStats.weaponHitLayers)) return;

                hitLocation = hit.point;
                DealDamage(hit);

                Vector3 hitDirection = hit.point - mainCamera.transform.position;
                Debug.DrawRay(mainCamera.transform.position, hitDirection.normalized * weaponStats.fireDistance, Color.red, 1);
            }
        }
        else if (weaponStats.bulletsInClip <= 0)
        {
            weaponHolder.StartReloading();
        }
    }
}
