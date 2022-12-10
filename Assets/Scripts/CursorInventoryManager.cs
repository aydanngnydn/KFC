using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using Unity.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CursorInventoryManager: Singleton<CursorInventoryManager>
{
	[SerializeField] [ReadOnly] private Moveable Inventory;
	[SerializeField] private LayerMask HolderMask;


	public bool AddToInventory(Moveable moveable)
	{
		if (Inventory) return false;

		Inventory = moveable;
		return true;
	}

	private void Update()
	{
		if(!Inventory) return;
		
		if (Input.GetMouseButtonUp(0))
		{
			var holder = GetHolderObject();
			if (holder)
			{
				var used = holder.OnMoveableDropped(Inventory);
				if (!used)
				{
					Inventory.ResetPos();
				}
			}
			RemoveSelfFromInventory();
		}
	}

	private Holder GetHolderObject()
	{
		//var a = Physics2D.Raycast(new Ray(Inventory.transform.position, Vector3.forward),out var hitInfo, 10000f,HolderMask);
		var hitInfo = Physics2D.OverlapPoint(Inventory.transform.position, HolderMask);
		return !hitInfo ? null : hitInfo.GetComponent<Holder>();
	}

	public void RemoveSelfFromInventory()
	{
		Inventory = null;
	}

	public Moveable GetInventoryItem()
	{
		return Inventory;
	}
	
}