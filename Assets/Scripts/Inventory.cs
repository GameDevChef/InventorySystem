using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Inventory System/Inventory")]
public class Inventory : ScriptableObject
{
    [SerializeField] private List<InventoryItemWrapper> items = new List<InventoryItemWrapper>();
    [SerializeField] private InventoryUI inventoryUIPrefab;

    private InventoryUI _inventoryUI;
    private InventoryUI inventoryUI
    {
        get
        {
            if (!_inventoryUI)
            {
                _inventoryUI = Instantiate(inventoryUIPrefab, playerEquipment.GetUIParent());
            }
            return _inventoryUI;
        }
    }

    private Dictionary<InventoryItem, int> itemToCountMap = new Dictionary<InventoryItem, int>();
    private PlayerEquipmentController playerEquipment;

    public void InitInventory(PlayerEquipmentController playerEquipment)
    {
        this.playerEquipment = playerEquipment;
        for (int i = 0; i < items.Count; i++)
        {
            itemToCountMap.Add(items[i].GetItem(), items[i].GetItemCount());
        }
    }

    public void OpenInventoryUI()
    {
        inventoryUI.gameObject.SetActive(true);
        inventoryUI.InitInventoryUI(this);
    }

    public void AssignItem(InventoryItem item)
    {
        item.AssignItemToPlayer(playerEquipment);
    }

    public Dictionary<InventoryItem, int> GetAllItemsMap()
    {
        return itemToCountMap;
    }

    public void AddItem(InventoryItem item, int count)
    {
        int currentItemCount;
        if(itemToCountMap.TryGetValue(item, out currentItemCount))
        {
            itemToCountMap[item] = currentItemCount + count;
        }
        else
        {
            itemToCountMap.Add(item, count);
        }
        inventoryUI.CreateOrUpdateSlot(this, item, count);
    }

    public void RemoveItem(InventoryItem item, int count)
    {
        int currentItemCount;
        if (itemToCountMap.TryGetValue(item, out currentItemCount))
        {
            itemToCountMap[item] = currentItemCount - count;
            if(currentItemCount - count <= 0)
            {
                inventoryUI.DestroySlot(item);
            }
            else
            {
                inventoryUI.UpdateSlot(item, currentItemCount - count);
            }
        }
        else
        {
            Debug.Log(string.Format("Cant remove {0}. This item is not in the inventory"));
        }
    }
}
