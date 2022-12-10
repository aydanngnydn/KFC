using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Chicken : Moveable
{
    [SerializeField] protected float age = 0;
    [SerializeField] protected float agingRate;
    [SerializeField] protected float hunger;
    [SerializeField] protected float hungerRate;
    [SerializeField] protected GameObject eggPrefab;
    
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