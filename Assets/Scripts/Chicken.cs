using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Chicken : Moveable
{
    [SerializeField] protected float age = 0;
    [SerializeField] protected float agingRate;
    [SerializeField] protected float hunger;
    [SerializeField] protected float hungerRate;
    [SerializeField] protected GameObject eggPrefab;
    [SerializeField] protected int defaultEggLayingSecond = 30;
    [SerializeField] public int id;

    
    [Header("Genes")]
    [SerializeField] protected float foodEff;
    [SerializeField] protected float agingSpeed;
    [SerializeField] protected float LaySpeed = 1f;
    public float layTime { get; set; } = 0;

    public Pen pen;


    public float LayEggTimer
    {
        get => _layEggTimer;
        set
        {
            _layEggTimer = value;
            if (layTime <= _layEggTimer)
            {
                LayEgg();
                _layEggTimer -= layTime;
                layTime = (defaultEggLayingSecond / LaySpeed) + Random.Range(-5, 6);
            }
        }
    }

    private float _layEggTimer = 0;
    
    
    private void Start()
    {
        layTime = (defaultEggLayingSecond / LaySpeed) + Random.Range(-5, 6);
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