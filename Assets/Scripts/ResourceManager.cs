using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class ResourceManager : Singleton<ResourceManager>
{
    [SerializeField] [ReadOnly] private float money;


    public void EarnMoney(float value)
    {
        money += value;
    }
    
    public void SpendMoney(float value)
    {
        if(money >= value)
            money -= value;
    }
    
    public float GetMoney()
    {
        return money;
    }
    
}
