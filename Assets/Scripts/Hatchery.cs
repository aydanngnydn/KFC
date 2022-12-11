using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hatchery : Holder
{
	public Egg incubatingEgg;

	[SerializeField] private UnityEvent OnEggHatch;
	
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
		OnEggHatch?.Invoke();
		MakeChick();
		DeleteEgg();
	}

	private void MakeChick()
	{
		Instantiate(incubatingEgg.chick, incubatingEgg.transform.position, incubatingEgg.transform.rotation, null);
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
		egg.Holdable = false;
		return true;

	}
}
