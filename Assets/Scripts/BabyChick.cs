using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyChick : Moveable
{
    [SerializeField] private Chicken _chicken;
    [SerializeField] int chickenTime;
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
    }
}
