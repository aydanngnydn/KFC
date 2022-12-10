using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Moveable: Holdable
{
	protected bool OnHand;
	private Vector3 _mousePositionFrameBefore;
	protected override void OnMouseHover()
	{
	}

	protected override void OnLeftMouseDown()
	{
		_mousePositionFrameBefore = Input.mousePosition;
	}

	protected override void OnRightMouseDown()
	{
	}

	protected override void OnLeftMouseUp()
	{
		OnHand = false;
	}

	protected override void OnRightMouseUp()
	{
	}

	protected override void OnMouseDragging()
	{
		OnHand = true;
		var mouseDelta = Input.mousePosition - _mousePositionFrameBefore;
		_mousePositionFrameBefore = Input.mousePosition;
		var objectDisplacement = new Vector3(mouseDelta.x * 2 * Camera.main.orthographicSize / Camera.main.pixelHeight,mouseDelta.y * 2 * Camera.main.orthographicSize / Camera.main.pixelHeight,0);
		transform.Translate(objectDisplacement);
	}
}