using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Chicken : Moveable
{
    [SerializeField] protected float age = 0;
    [SerializeField] protected float hunger;
    [SerializeField] protected float hungerRate;
    //Pen pen;
    [SerializeField] protected float laySpeed;
    [SerializeField] protected float foodEff;
    [SerializeField] protected float agingSpeed;

    private void Start()
    {
        StartCoroutine(GetOlder());
    }

    private IEnumerator GetOlder()
    {
        age += 1;
        yield return new WaitForSeconds(agingSpeed);

    }

    protected void LayEgg()
    {
        
    }

    
}
