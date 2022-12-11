using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BabyChick : Chicken
{
    [SerializeField] int chickenTime = 15;
    [SerializeField] GameObject chicken;
    private int timer = 0;
    

    private void Start()
    {
        timer = 0;
        _movement = GetComponent<Movement>();
        StartCoroutine(IncreaseTimer());
    }

    private IEnumerator IncreaseTimer()
    {
        while (timer < chickenTime)
        {
            timer++;
            yield return new WaitForSeconds(1f);
        }

        var chickenNew = Instantiate(chicken, transform.position, transform.rotation,null).GetComponent<Chicken>();
        if (pen)
        {
            pen.RemoveChicken(this);
            pen.AddChicken(chickenNew);
        }
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
