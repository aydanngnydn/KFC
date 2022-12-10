using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Chicken : Moveable
{
    [SerializeField] protected float age = 0;
    [SerializeField] protected float agingRate;
    [SerializeField] protected float hunger;
    [SerializeField] protected float hungerRate;
    [SerializeField] protected GameObject eggPrefab;
    [SerializeField] public int id;

    
    [Header("Genes")]
    [SerializeField] protected float foodEff;
    [SerializeField] protected float agingSpeed;

    public Pen pen;
    public float layTime { get; set; } = 0;
    public float LayEggTimer { get; set; } = 0;

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