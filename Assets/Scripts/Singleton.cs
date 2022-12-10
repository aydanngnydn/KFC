using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
	public static T I;
	protected virtual void Awake()
	{
		if (I == null)
		{
			I = this as T;
		}

		if (I != this)
		{
			Destroy(gameObject);
		}
	}
}