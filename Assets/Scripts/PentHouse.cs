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
        Debug.Log(ChickenCombination(a,b));
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
