using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Holdable : MonoBehaviour
{
	private bool mouseOver = false;
	
	private void OnMouseOver()
	{
		OnMouseHover();
	}

	private void OnMouseEnter()
	{
		mouseOver = true;
	}

	private void OnMouseExit()
	{

		mouseOver = false;
	}

	protected void OnMouseDown()
	{
		if (!mouseOver) return;

		
		if (Input.GetMouseButtonDown(0))
		{
			OnLeftMouseDown();
		}
		else if(Input.GetMouseButtonDown(1))
		{
			OnRightMouseDown();
		}
	}

	private void OnMouseUp()
	{
		if (!mouseOver) return;

		
		if (Input.GetMouseButtonUp(0))
		{
			OnLeftMouseUp();
		}
		else if(Input.GetMouseButtonUp(1))
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