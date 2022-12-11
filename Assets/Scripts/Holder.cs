using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Holder : Mousable
{
	[SerializeField] private UnityEvent OnMoveableAdded;
	protected override void OnMouseHover()
	{
		
	}

	protected override void OnLeftMouseDown()
	{
		
	}

	protected override void OnRightMouseDown()
	{
		
	}

	protected override void OnLeftMouseUp()
	{

	}

	protected override void OnRightMouseUp()
	{
		
	}

	protected override void OnMouseDragging()
	{
		
	}

	public virtual bool OnMoveableDropped(Moveable selected)
	{
		OnMoveableAdded?.Invoke();
		return true;
	}
}