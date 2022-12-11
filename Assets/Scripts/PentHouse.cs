using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class PentHouse : Holder
{
    public Chicken a;
    public Chicken b;
    [SerializeField] private List<HachingChanceThing> thingy;

    private void Start()
    {
    }

    public int ChickenCombination(Chicken chick1, Chicken chick2)
    {
        int i = 0;
        while ((thingy[i].sum != chick1.id + chick2.id) || (thingy[i].multiplication != chick1.id * chick2.id))
        {
            i++;
        }

        return thingy[i].eggChances.ChooseFromOptions().value;
    }
    
    public void RemoveChickens()
    {
	    a.Holdable = true;
	    b.Holdable = true;
	    a = null;
	    b = null;
    }

    protected override void OnRightMouseDown()
    {
	    base.OnRightMouseDown();
	    RemoveChickens();
    }

    public void AddChicken(Chicken chicken)
    	{
	        if (!a && chicken != b)
	        {
		        a = chicken;
		        return;
	        }

	        if (!b && chicken != a)
	        {
		        b = chicken;
		        return;
	        }
    
    	}
    
    	public override bool OnMoveableDropped(Moveable selected)
    	{
    		var chicken = selected as Chicken;
    		
    		if (!chicken || (a && b)) return false;

            if (chicken.pen)
            {
	            chicken.pen.RemoveChicken(chicken);
				chicken.pen = null;
            }
    		AddChicken(chicken);
            chicken.Holdable = false;
            chicken.MovementMode(false);
    		return true;
    
    	}
}

[Serializable]
public class HachingChanceThing
{
    public WeightedList<Egg>  eggChances;
    [SerializeField] private int chick1;
    [SerializeField] private int chick2;

    public int sum => chick1 + chick2;
    public int multiplication => chick1 * chick2;

}

[Serializable]
public class WeightedList<T>
{
    public List<WeightedElement<T>> chickenTypes;
    private int totalWeight = 10;
    public WeightedElement<T> ChooseFromOptions()
    {
        int rand = Random.Range(0, totalWeight + 1);
        int pos = 0;
        for (int i=0; i < chickenTypes.Count; i++)
        {
            if(rand <= chickenTypes[i].weight + pos)
            {
                return chickenTypes[i];
            }
            pos += chickenTypes[i].weight;
        }

        return null;
    }
}
[Serializable]
public class WeightedElement<T>
{
    public int value;
    public int weight;
}
