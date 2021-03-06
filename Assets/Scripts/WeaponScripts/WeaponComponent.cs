using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    None,
    Pistol,
    MachineGun,
    Shotgun,
    Sniper
}

public enum WeaponFiringPattern
{
    SemiAutio, FullAutio, ThreeShotBurst, FiveShotBurst, Spread
}

[System.Serializable]
public struct WeaponStats
{
    public WeaponType weaponType;
    public string weaponName;
    public float damage;
    public int bulletsInClip;
    public int clipSize;
    public float fireStartDelay;
    public float fireRate;
    public WeaponFiringPattern weaponFiringPattern;
    public float fireDistance;
    public bool repeating;
    public LayerMask weaponHitLayers;
    public int totalBullets;
    public int bulletsPerShot;
}

public class WeaponComponent : MonoBehaviour
{
    [Header("Prefab")]
    public GameObject weaponPrefab;

    public Transform gripLocation;
    public Transform firingEffectLocation;

    protected WeaponHolder weaponHolder;
    [SerializeField]
    protected ParticleSystem firingEffect;

    [SerializeField]
    public WeaponStats weaponStats;

    public float realDamage
    {
        get
        {
            return weaponStats.damage * weaponHolder.GetComponent<PlayerStats>().damageMultiplier;
        }
    }

    public bool isFiring = false;
    public bool isReloading = false;

    public Camera mainCamera;

    // Start is called before the first frame update
    void Awake()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize(WeaponHolder _weaponHolder)
    {
        weaponHolder = _weaponHolder;

        var main = firingEffect.main;
        main.loop = weaponStats.repeating;
    }

    public virtual void StartFiringWeapon()
    {
        isFiring = true;

        if (weaponStats.repeating)
        {
            InvokeRepeating(nameof(FireWeapon), weaponStats.fireStartDelay, weaponStats.fireRate);
        }
        else
        {
            FireWeapon();
        }
    }

    public virtual void StopFiringWeapon()
    {
        isFiring = false;
        CancelInvoke(nameof(FireWeapon));
        if (firingEffect.isPlaying)
        {
            firingEffect.Stop();
        }
    }

    protected virtual void FireWeapon()
    {
        weaponStats.bulletsInClip--;
    }

    // Deal with ammo counts and maybe particle effects
    public virtual void StartReloading()
    {
        isReloading = true;
        ReloadWeapon();
    }

    public virtual void StopReloading()
    {
        isReloading = false;
    }

    protected virtual void ReloadWeapon()
    {
        if (firingEffect.isPlaying)
        {
            firingEffect.Stop();
        }

        int bulletsToReload = weaponStats.clipSize - weaponStats.totalBullets;
        if (bulletsToReload < 0)
        {
            int bulletsLeftInClip = weaponStats.bulletsInClip;
            weaponStats.bulletsInClip = weaponStats.clipSize;
            weaponStats.totalBullets -= (weaponStats.clipSize - bulletsLeftInClip);
        }
        else
        {
            weaponStats.bulletsInClip = weaponStats.totalBullets;
            weaponStats.totalBullets = 0;
        }
    }

    public void AddAmmo(int ammo)
    {
        weaponStats.totalBullets += ammo;
    }

    protected void DealDamage(RaycastHit hitInfo)
    {
        IDamagable damageable = hitInfo.collider.GetComponent<IDamagable>();
        damageable?.TakeDamage(realDamage);
    }
}
