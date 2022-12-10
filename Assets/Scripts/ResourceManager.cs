using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : Singleton<ResourceManager>
{
    public Dictionary<int, int> eggDict;
    private int money;
    private int seed;

    public void AddEgg(int eggID)
    {
        if (eggDict.ContainsKey(eggID)) eggDict[eggID] += 1;
        
        else eggDict.Add(eggID, 1);
    }

    public void SellEgg( int eggID)
    {
        eggDict[eggID] -= 1;
    }

    public bool TrySpendMoney(int _money)
    {
        if (money < _money) return false;
        else money -= _money;
        return true;
    }
}
