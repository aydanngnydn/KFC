using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : Moveable
{
    public BabyChick chick;
    public int id;
    public float timer = 0;
    public float hatchTime;
    [SerializeField] private  float value;
    public Animator _animator;

    protected override void OnRightMouseDown()
    {
        base.OnRightMouseDown();
        ResourceManager.I.EarnMoney(value);
        Destroy(gameObject);
    }
}
