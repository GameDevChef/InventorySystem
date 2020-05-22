using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipmentController : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private Transform inventoryUIParent;

    [Header("Anchors")]
    [SerializeField] private Transform helmetAnchor;

	

	[SerializeField] private Transform leftHandAnchor;
    [SerializeField] private Transform rightHandAnchor;
    [SerializeField] private Transform armorAnchor;

    private GameObject currentHelmetObj;
    private GameObject currentLeftHandObj;
    private GameObject currentRighHandObj;
    private GameObject currentArmorObj;
    private int playerHealth = 0;

    private void Start()
    {
        inventory.InitInventory(this);
        inventory.OpenInventoryUI();
    }

	public void AssignHelmetItem(HelmetInventoryItem item)
	{
        DestroyIfNotNull(currentHelmetObj);
        currentHelmetObj = CreateNewItemInstance(item, helmetAnchor);
	}

    public void AssignHandItem(HandInventoryItem item)
    {
        switch (item.hand)
        {
            case Hand.LEFT:
                DestroyIfNotNull(currentLeftHandObj);
                currentLeftHandObj = CreateNewItemInstance(item, leftHandAnchor);
                break;
            case Hand.RIGHT:
                DestroyIfNotNull(currentRighHandObj);
                currentRighHandObj = CreateNewItemInstance(item, rightHandAnchor);
                break;
            default:
                break;
        }
    }

    public void AssingArmorItem(ArmorInventoryItem item)
    {
        DestroyIfNotNull(currentArmorObj);
        currentArmorObj = CreateNewItemInstance(item, armorAnchor);
    }

    public void AssingHealthPotionItem(HealthPotionInventoryItem item)
    {
        inventory.RemoveItem(item, 1);
        playerHealth += item.GetHealthPoints();
        Debug.Log(string.Format("Player has now {0} health points", playerHealth));
    }

    private GameObject CreateNewItemInstance(InventoryItem item, Transform anchor)
    {
        var itemInstance = Instantiate(item.GetPrefab(), anchor);
        itemInstance.transform.localPosition = item.GetLocalPosition();
        itemInstance.transform.localRotation = item.GetLocalRotation();
        return itemInstance;
    }

    private void DestroyIfNotNull(GameObject obj)
    {
        if (obj)
        {
            Destroy(obj);
        }
    }

    public Transform GetUIParent()
    {
        return inventoryUIParent;
    }
}
