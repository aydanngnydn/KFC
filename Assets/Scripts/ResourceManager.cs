using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ResourceManager : Singleton<ResourceManager>
{
    [SerializeField] [ReadOnly] private float money;
    [SerializeField] private UnityEvent MoneyCome;

    public void EarnMoney(float value)
    {
        money += value;
        MoneyCome?.Invoke();
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
