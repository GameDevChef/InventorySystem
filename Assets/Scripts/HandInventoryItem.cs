using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Hand { LEFT, RIGHT };

[CreateAssetMenu(menuName = "Scriptable Objects/Inventory System/Items/Hand Item")]
public class HandInventoryItem : InventoryItem
{
    public Hand hand;
    public override void AssignItemToPlayer(PlayerEquipmentController playerEquipment)
    {
        playerEquipment.AssignHandItem(this);
    } 
}
