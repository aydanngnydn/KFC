using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : Moveable
{
    private Chicken chicken;
    public int id;
    [SerializeField] public float timer = 0, hatchTime;
    [SerializeField] float value;

}
