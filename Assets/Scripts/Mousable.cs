using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mousable : MonoBehaviour
{
	private void OnMouseOver()
	{
		OnMouseHover();
		
		if (Input.GetMouseButtonDown(0))
		{
			OnLeftMouseDown();
		}
		if(Input.GetMouseButtonDown(1))
		{
			OnRightMouseDown();
		}
		
		if (Input.GetMouseButtonUp(0))
		{
			OnLeftMouseUp();
		}
		if(Input.GetMouseButtonUp(1))
		{
			OnRightMouseUp();
		}
	}

	private void OnMouseDrag()
	{
		OnMouseDragging();
	}

	protected abstract void OnMouseHover();
	protected abstract void OnLeftMouseDown();
	protected abstract void OnRightMouseDown();
	protected abstract void OnLeftMouseUp();
	protected abstract void OnRightMouseUp();
	protected abstract void OnMouseDragging();
}