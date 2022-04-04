using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickupComponent : MonoBehaviour
{
    [SerializeField]
    ItemScript pickupItem;

    [Tooltip("Manual Override for drop amount, if left at -1 it will use the amount from the scriptable object")]
    int amount = -1;

    [SerializeField]
    MeshRenderer propMeshRenderer;

    [SerializeField]
    MeshFilter propMeshFilter;

    ItemScript itemInstance;

    PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        InstantiateItem();
        playerController = FindObjectOfType<PlayerController>();
    }

    private void InstantiateItem()
    {
        itemInstance = Instantiate(pickupItem);

        if (amount > 0)
        {
            itemInstance.SetAmount(amount);
        }

        ApplyMesh();
    }

    private void ApplyMesh()
    {
        if (propMeshFilter) propMeshFilter.mesh = pickupItem.itemPrefab.GetComponentInChildren<MeshFilter>().sharedMesh;
        if (propMeshRenderer) propMeshRenderer.materials = pickupItem.itemPrefab.GetComponentInChildren<MeshRenderer>().sharedMaterials;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        playerController.inventory.AddItem(itemInstance);

        Destroy(gameObject);
    }
}
