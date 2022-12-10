using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;


public class PentHouse : MonoBehaviour
{
    [SerializeField] private WeightedList<int> a ;
    
}

public class ChickComb : MonoBehaviour
{
    private Chicken chick1;
    private Chicken chick2;
    private WeightedList<Chicken> typeList;

    void ChickenCombination(Chicken chick1, Chicken chick2)
    {
        if (chick1.id == chick2.id)
        {
            
        }
    }
}

[Serializable]
public class WeightedList<T>
{
    public List<WeightedElement<T>> a;
    private int totalWeight = 0;
    
    public T GetRandomElement() 
    {
        foreach (WeightedElement<T> el in a)
        {
            totalWeight += el.weight;
        }

        return ChooseFromOptions().value;
    }

    private WeightedElement<T> ChooseFromOptions()
    {
        int rand = Random.Range(0, totalWeight + 1);
        int pos = 0;
        for (int i=0; i < a.Count; i++)
        {
            if(rand <= a[i].weight + pos)
            {
                return a[i];
            }
            pos += a[i].weight;
        }

        return null;
    }
}
[Serializable]
public class WeightedElement<T>
{
    public T value;
    public int weight;
}
