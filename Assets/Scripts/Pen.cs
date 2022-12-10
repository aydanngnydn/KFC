using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pen:Holder
{
	[SerializeField] private int capacity;
	public List<Chicken> chickens = new List<Chicken>();
	public List<Egg> eggs = new List<Egg>();
	private void Start()
	{
		StartCoroutine(LayEgg());
	}

	private IEnumerator LayEgg()
	{
		while (true)
		{
			foreach (Chicken chick in chickens)
			{
				chick.LayEggTimer += 1;
				
				if (chick.layTime >= chick.LayEggTimer) break;
			}
			yield return new WaitForSeconds(1f);
		}
	}

	protected override void OnLeftMouseUp()
	{
		base.OnLeftMouseUp();
		var inventoryItem = CursorInventoryManager.I.GetInventoryItem();
		var item = inventoryItem as Chicken;
		if (!item || (chickens.Count >= capacity))
		{
			inventoryItem.ResetPos();
			return;
		}

		if (item.pen)
		{
			item.pen.RemoveChicken(item);
		}
		AddChicken(item);
		item.pen = this;
	}

	public void RemoveChicken(Chicken chicken)
	{
		chickens.Remove(chicken);
	}
	
	public void AddChicken(Chicken chicken)
	{
		chickens.Add(chicken);

	}

	public override bool OnMoveableDropped(Moveable selected)
	{
		var chicken = selected as Chicken;
		
		if (!chicken) return false;
		
		AddChicken(chicken);
		return true;

	}
}