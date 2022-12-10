using System;
using System.Diagnostics.CodeAnalysis;
using Unity.Collections;
using UnityEngine;

public class CursorInventoryManager: Singleton<CursorInventoryManager>
{
	[SerializeField] [ReadOnly] private Mousable Inventory;


	public bool AddToInventory(Moveable moveable)
	{
		if (Inventory) return false;

		Inventory = moveable;
		return true;
	}
	

	public void RemoveSelfFromInventory()
	{
		Inventory = null;
	}

	public Mousable GetInventoryItem()
	{
		return Inventory;
	}
}