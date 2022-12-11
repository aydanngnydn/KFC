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
    [SerializeField] private List<Egg> eggPrefabs;
    [SerializeField] private GameObject basket;
    private Vector3 maxCorner, minCorner;
  


    private void Start()
    {
	    maxCorner = basket.GetComponent<Collider2D>().bounds.max;
	    minCorner = basket.GetComponent<Collider2D>().bounds.min;
	    
    }

    public void ChickenCombination(Chicken chick1, Chicken chick2)
    {
        int i = 0, j = 0;
        while (i < thingy.Count )
        {
	        if ((thingy[i].sum != chick1.id + chick2.id) || (thingy[i].multiplication != chick1.id * chick2.id))
	        {
		        i++;
	        }
	        else break;

        }

        int newEggID = thingy[i].eggChances.ChooseFromOptions().value;
        while ( j < eggPrefabs.Count )
        {
	        if (newEggID != eggPrefabs[j].id)
		        j++;
	        else break;
        }

        float xPos = Random.Range(minCorner.x, maxCorner.x);
        float yPos = Random.Range(minCorner.y, maxCorner.y);
        Instantiate(eggPrefabs[j], new Vector3(xPos, yPos, 0), Quaternion.identity);
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
            
            if (a && b)
            {
	            ChickenCombination(a, b);
            }
            
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