using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Egg : Moveable
{
    private Chicken chicken;
    [SerializeField] protected float hatchTime;
    [SerializeField] protected float value;
    
}
