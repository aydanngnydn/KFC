using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : Moveable
{
    public Chicken chicken;
    public int id;
    public float timer = 0;
    public float hatchTime;
    [SerializeField] float value;

}
