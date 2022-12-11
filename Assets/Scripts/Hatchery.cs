using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hatchery : Holder
{
	public Egg incubatingEgg;
	public Moveable chick;
	
	private void Start()
	{
		StartCoroutine(EggTimerCoroutine());
	}

	IEnumerator EggTimerCoroutine()
	{
		while (true)
		{
			yield return null;
			if (!incubatingEgg) continue;
			incubatingEgg.timer += Time.deltaTime;
			if (incubatingEgg.timer >= incubatingEgg.hatchTime)
			{
				HatchEgg();
			}
		}
		
		
	}

	public void HatchEgg()
	{
		MakeChick();
		DeleteEgg();
	}

	private void MakeChick()
	{
		Debug.Log($"BORN AND STUFF");
		//TODO:implement with chick or smtn
	}

	public void DeleteEgg()
	{
		Destroy(incubatingEgg.gameObject);
		incubatingEgg = null;
	}
	
	public bool IncubateEgg(Egg egg)
	{
		if (incubatingEgg) return false;
		incubatingEgg = egg;
		return true;
	}

	public override bool OnMoveableDropped(Moveable selected)
	{
		var egg = selected as Egg;
		
		if (!egg || incubatingEgg) return false;
		
		IncubateEgg(egg);
		return true;

	}
}
