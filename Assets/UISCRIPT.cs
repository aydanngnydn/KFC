using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UISCRIPT : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshProUGUI;
    
    public void UpdateText()
    {
        _textMeshProUGUI.text = $":{ResourceManager.I.GetMoney()}";
    }
}
