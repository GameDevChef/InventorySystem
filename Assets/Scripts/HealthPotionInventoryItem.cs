using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Inventory System/Items/Health Potion")]
public class HealthPotionInventoryItem : InventoryItem
{
    [SerializeField] private int healthPoints;
    public override void AssignItemToPlayer(PlayerEquipmentController playerEquipment)
    {
        playerEquipment.AssingHealthPotionItem(this);
    }

    public int GetHealthPoints()
    {
        return healthPoints;
    }
}
