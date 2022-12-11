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
				chick.LayEggTimer += Time.deltaTime;
			}
			yield return null;
		}
	}

	public void RemoveChicken(Chicken chicken)
	{
		chickens.Remove(chicken);
	}
	
	public void AddChicken(Chicken chicken)
	{
		chickens.Add(chicken);
		if (chicken.pen)
		{
			chicken.pen.RemoveChicken(chicken);
		}

		chicken.pen = this;

	}

	public override bool OnMoveableDropped(Moveable selected)
	{
		var chicken = selected as Chicken;
		
		if (!chicken || chickens.Count >= capacity) return false;
		
		AddChicken(chicken);
		chicken.MovementMode(true);

		return true;

	}
}