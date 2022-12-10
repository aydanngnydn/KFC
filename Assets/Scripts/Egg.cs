using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Egg : MonoBehaviour
{
    private Chicken chicken;
    [SerializeField] protected float hatchTime;
    [SerializeField] protected float value;
}
