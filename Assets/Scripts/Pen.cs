using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pen:Holder
{
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
		var item = CursorInventoryManager.I.GetInventoryItem() as Chicken;
		if (!item) return;

		AddChicken(item);
		item.pen.RemoveChicken(item);
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
}