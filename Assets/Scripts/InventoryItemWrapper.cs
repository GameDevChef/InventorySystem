using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryItemWrapper
{
	[SerializeField] private InventoryItem item;
	[SerializeField] private int count;

	public InventoryItem GetItem()
	{
		return item;
	}

	public int GetItemCount()
	{
		return count;
	}
}
