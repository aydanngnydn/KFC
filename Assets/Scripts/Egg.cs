using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Egg : Moveable
{
    private Chicken chicken;
    private int id;
    [SerializeField] protected float hatchTime;
    [SerializeField] protected float value;
    
}
