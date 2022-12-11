using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Chicken : Moveable
{
    [SerializeField] protected float age = 0;
    [SerializeField] protected float hunger;
    [SerializeField] protected GameObject eggPrefab;
    [SerializeField] protected int defaultEggLayingSecond = 30;
    [SerializeField] protected int defaultOldAgeSecond = 300;
    [SerializeField] public int id;
    [SerializeField] public GameObject OldChickenPrefab;

    
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

    private float oldAge = 0;
    private float _layEggTimer = 0;
    protected Movement _movement;
    private bool movementMode = true;
    
    
    protected virtual void Start()
    {
        _movement = GetComponent<Movement>();
        oldAge = defaultOldAgeSecond * agingSpeed + Random.Range(-75,76);
        layTime = (defaultEggLayingSecond / LaySpeed) + Random.Range(-5, 6);
        StartCoroutine(GetOlder());
    }

    protected virtual IEnumerator GetOlder()
    {
        while (true)
        {
            age += Time.deltaTime;
            if (oldAge <= age)
            {
                GetOld();
            }
            yield return null;
        }

    }

    protected virtual void GetOld()
    {
        Instantiate(OldChickenPrefab, transform.position, transform.rotation, null);
        
        Destroy(gameObject);
    }

    protected override void OnLeftMouseDown()
    {
        base.OnLeftMouseDown();
        if (!Holdable) return;
        movementMode = _movement.stop;
        _movement.stop = true;
    }
    protected override void OnLeftMouseUp()
    {
        base.OnLeftMouseUp();
        if (!Holdable) return;
        _movement.stop = movementMode;
    }

    public void MovementMode(bool move)
    {
        _movement.stop = !move;
    }

    protected virtual void LayEgg()
    {
       Instantiate(eggPrefab, transform.position, transform.rotation, null);
       
    }

  
}