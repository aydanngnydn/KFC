using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BabyChick : Chicken
{
    [SerializeField] int chickenTime = 15;
    private GameObject chicken;
    private int timer = 0;
    

    private void Start()
    {
        timer = 0;
        StartCoroutine(IncreaseTimer());
    }

    private IEnumerator IncreaseTimer()
    {
        while (timer < chickenTime)
        {
            timer++;
            yield return new WaitForSeconds(1f);
        }

        Instantiate(chicken, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }

    protected override IEnumerator GetOlder()
    {
        yield return null;
    }

    protected override void LayEgg()
    {
    }
}
