using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hatchery : Holder
{
	public Egg incubatingEgg;

	private bool eggHatched = false;
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
			if (incubatingEgg.timer >= incubatingEgg.hatchTime && !eggHatched)
			{
				eggHatched = true;
				HatchEgg();
			}
		}
		
		
	}

	public void HatchEgg()
	{
		OnEggHatch?.Invoke();
		DeleteEgg();
		StartCoroutine(LateInstantiate());
	}

	private IEnumerator LateInstantiate()
	{
		var t = 0f;

		while (t < 2.51f)
		{
			t += Time.deltaTime;
			yield return null;
		}
		MakeChick();
	}

	private void MakeChick()
	{
		Debug.Log($"{incubatingEgg == null}");
		Instantiate(incubatingEgg.chick, incubatingEgg.transform.position, incubatingEgg.transform.rotation, null);
		Debug.Log($"{incubatingEgg.chick}");

		Destroy(incubatingEgg.gameObject);
		incubatingEgg = null;

	}

	public void DeleteEgg()
	{
		incubatingEgg._animator.SetTrigger("Hatch");
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
		eggHatched = false;
		return true;

	}
}
