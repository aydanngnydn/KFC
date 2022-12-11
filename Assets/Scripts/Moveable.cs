using System.Collections;
using UnityEngine;

public class Moveable: Mousable
{
	public bool Holdable = true;
	public bool OnInventory { get; set; } = false;
	private Vector3 _mousePositionFrameBefore;
	private Vector3 _startPos;
	protected override void OnMouseHover()
	{
	}

	protected override void OnLeftMouseDown()
	{
		if (!Holdable) return;
		OnInventory = CursorInventoryManager.I.AddToInventory(this);
		_startPos = transform.position;
		_mousePositionFrameBefore = Input.mousePosition;
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
		if (!OnInventory) return;
		var mouseDelta = Input.mousePosition - _mousePositionFrameBefore;
		_mousePositionFrameBefore = Input.mousePosition;
		var objectDisplacement = new Vector3(mouseDelta.x * 2 * Camera.main.orthographicSize / Camera.main.pixelHeight,mouseDelta.y * 2 * Camera.main.orthographicSize / Camera.main.pixelHeight,0);
		transform.Translate(objectDisplacement);
	}

	public void ResetPos()
	{
		transform.position = _startPos;
	}
	
}