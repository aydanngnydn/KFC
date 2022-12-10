using UnityEngine;

public class BodgeZDiffrentiator:MonoBehaviour
{
	[SerializeField] private float offset;
	private void Update()
	{
		var transformPos = transform.position;
		transform.position = new Vector3(transformPos.x, transformPos.y, transformPos.y + offset);
	}
}