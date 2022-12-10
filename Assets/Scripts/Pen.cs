using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pen:Holdable
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
				chick.timer += 1;
				
				if (chick.layTime == chick.timer) break;
			}
			yield return new WaitForSeconds(1f);
		}
	}

	protected override void OnMouseHover()
	{
		throw new NotImplementedException();
	}

	protected override void OnLeftMouseDown()
	{
		throw new NotImplementedException();
	}

	protected override void OnRightMouseDown()
	{
		throw new NotImplementedException();
	}

	protected override void OnLeftMouseUp()
	{
		throw new NotImplementedException();
	}

	protected override void OnRightMouseUp()
	{
		throw new NotImplementedException();
	}

	protected override void OnMouseDragging()
	{
		throw new NotImplementedException();
	}
}