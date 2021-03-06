using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponHolder : MonoBehaviour
{
    [Header("WeaponToSpawn"), SerializeField]
    WeaponItem weaponToSpawn;

    public PlayerController playerController;
    Animator animator;
    Sprite crosshairImage;
    public WeaponComponent equippedWeapon;

    [SerializeField]
    GameObject weaponSocketLocation;
    [SerializeField]
    Transform gripIKSocketLocation;

    bool wasFiring = false;
    bool firingPressed = false;


    public readonly int isFiringHash = Animator.StringToHash("IsFiring");
    public readonly int isRealoadingHash = Animator.StringToHash("IsReloading");


    private void OnEnable()
    {
        PlayerEvents.OnEquipWeapon += EquipWeapon;
    }

    private void OnDisable()
    {
        PlayerEvents.OnEquipWeapon -= EquipWeapon;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();

        playerController.inventory.AddItem(weaponToSpawn);
        playerController.inventory.FindItem("Pistol")?.UseItem(playerController);

        PlayerEvents.InvokeOnEquipWeapon(weaponToSpawn.itemPrefab.GetComponent<WeaponComponent>());
    }

    private void EquipWeapon(WeaponComponent weaponToEquip)
    {
        // Remove Old Weapon
        if (equippedWeapon) Destroy(equippedWeapon.gameObject);

        GameObject spawnedWeapon = Instantiate(weaponToEquip.weaponPrefab, weaponSocketLocation.transform.position, weaponSocketLocation.transform.rotation, weaponSocketLocation.transform);
        
        equippedWeapon = spawnedWeapon.GetComponent<WeaponComponent>();
        equippedWeapon.Initialize(this);

        PlayerEvents.InvokeOnWeaponEquipped(equippedWeapon);

        gripIKSocketLocation = equippedWeapon.gripLocation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnAnimatorIK(int layerIndex)
    {
        animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
        animator.SetIKPosition(AvatarIKGoal.LeftHand, gripIKSocketLocation.transform.position);
    }

    public void OnFire(InputValue value)
    {
        if (playerController.isInventoryOpen) return;

        firingPressed = value.isPressed;
        if (firingPressed)
        {
            StartFiring();
        }
        else
        {
            StopFiring();
        }
    }

    public void StartFiring()
    {
        if (equippedWeapon.weaponStats.bulletsInClip <= 0)
        {
            StartReloading();
            return;
        }
        animator.SetBool(isFiringHash, true);
        playerController.isFiring = true;
        equippedWeapon.StartFiringWeapon();
    }

    public void StopFiring()
    {
        playerController.isFiring = false;
        animator.SetBool(isFiringHash, false);
        equippedWeapon.StopFiringWeapon();
    }

    // Input based reload
    public void OnReload(InputValue value)
    {
        playerController.isReloading = value.isPressed;
        StartReloading();
    }

    // Action of reloading
    public void StartReloading()
    {
        // Return if we're already reloading or if we have the maximum clip size
        if (equippedWeapon.isReloading || equippedWeapon.weaponStats.bulletsInClip >= equippedWeapon.weaponStats.clipSize) return;

        if (playerController.isFiring)
        {
            StopFiring();
        }

        if (equippedWeapon.weaponStats.totalBullets <= 0) return;

        animator.SetBool(isRealoadingHash, true);
        equippedWeapon.StartReloading();

        InvokeRepeating(nameof(StopReloading), 0, 0.1f);
    }

    public void StopReloading()
    {
        if (animator.GetBool(isRealoadingHash)) return;

        playerController.isReloading = false;
        equippedWeapon.StopReloading();
        animator.SetBool(isRealoadingHash, false);
        CancelInvoke(nameof(StopReloading));
    }
}
