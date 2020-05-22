using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Transform slotsParent;
    [SerializeField] private InventorySlot slotPrefab;

    private Dictionary<InventoryItem, InventorySlot> itemToSlotMap = new Dictionary<InventoryItem, InventorySlot>();

    public void InitInventoryUI(Inventory inventory)
    {
        var itemsMap = inventory.GetAllItemsMap();
        foreach (var kvp in itemsMap)
        {
            CreateOrUpdateSlot(inventory, kvp.Key, kvp.Value);
        }
    }

    public void CreateOrUpdateSlot(Inventory inventory, InventoryItem item, int itemCount)
    {
        if (!itemToSlotMap.ContainsKey(item))
        {
            var slot = CreateSlot(inventory, item, itemCount);
            itemToSlotMap.Add(item, slot);
        }
        else
        {
            UpdateSlot(item, itemCount);
        }
    }

    public void UpdateSlot(InventoryItem item, int itemCount)
    {
        itemToSlotMap[item].UpdateSlotCount(itemCount);
    }

    private InventorySlot CreateSlot(Inventory inventory, InventoryItem item, int itemCount)
    {
        var slot = Instantiate(slotPrefab, slotsParent);
        slot.InitSlotVisualisation(item.GetSprite(), item.GetName(), itemCount);
        slot.AssingSlotButtonCallback(() => inventory.AssignItem(item));
        return slot;
    }

    public void DestroySlot(InventoryItem item)
    {
        Destroy(itemToSlotMap[item].gameObject);
        itemToSlotMap.Remove(item);
    }
}
