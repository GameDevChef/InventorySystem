using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
	[SerializeField] private Image itemImage;
	[SerializeField] private Text itemNameText;
	[SerializeField] private Text itemCountText;
	[SerializeField] private Button slotButton;

	public void InitSlotVisualisation(Sprite itemSprite, string itemName, int itemCount)
	{
		itemImage.sprite = itemSprite;
		itemNameText.text = itemName;
		UpdateSlotCount(itemCount);
	}

	public void UpdateSlotCount(int itemCount)
	{
		itemCountText.text = itemCount.ToString();
	}

	public void AssingSlotButtonCallback(System.Action onClickCallback)
	{
		slotButton.onClick.AddListener(() => onClickCallback());
	}
}
