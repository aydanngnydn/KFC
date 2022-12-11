using System.Collections;
using UnityEngine;

public class OldChicken : Chicken
{
	[SerializeField] private float defaultDeathSecond = 60;
	private float deathAge;
	private float ageNOW = 0;


	protected override void Start()
	{
		_movement = GetComponent<Movement>();
		deathAge = defaultDeathSecond + Random.Range(-25,26);
		StartCoroutine(GetDie());
	}

	private IEnumerator GetDie()
	{
		while (true)
		{
			ageNOW += Time.deltaTime;
			if (deathAge <= ageNOW)
			{
				Die();
			}
			yield return null;
		}

	}

	private void Die()
	{
		Destroy(gameObject, 2f);
	}

	protected override void OnLeftMouseDown()
	{
	}

	protected override void OnLeftMouseUp()
	{
	}
	
	protected override IEnumerator GetOlder()
	{
		yield return null;
	}

	protected override void LayEgg()
	{
	}
}