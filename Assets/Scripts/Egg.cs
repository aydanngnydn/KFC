using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Egg : Moveable
{
    private Chicken chicken;
    private int id;
    [SerializeField] public float timer = 0, hatchTime;
    [SerializeField] float value;

}
