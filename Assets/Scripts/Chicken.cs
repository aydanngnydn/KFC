using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Chicken : Moveable
{
    [SerializeField] protected float age = 0;
    [SerializeField] protected float agingRate;
    [SerializeField] protected float hunger;
    [SerializeField] protected float hungerRate;
    [SerializeField] protected GameObject eggPrefab;
    [SerializeField] protected Pen pen;
    
    [Header("Genes")]
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
       Instantiate(eggPrefab, transform.position, transform.rotation, null);
       
    }

    
}

public class Pen:Holdable
{
    public List<Chicken> chickens = new List<Chicken>();
    protected override void OnMouseHover()
    {
        throw new NotImplementedException();
    }

    protected override void OnLeftMouseDown()
    {
        throw new NotImplementedException();
    }

    protected override void OnRightMouseDown()
    {
        throw new NotImplementedException();
    }

    protected override void OnLeftMouseUp()
    {
        throw new NotImplementedException();
    }

    protected override void OnRightMouseUp()
    {
        throw new NotImplementedException();
    }

    protected override void OnMouseDragging()
    {
        throw new NotImplementedException();
    }
}
