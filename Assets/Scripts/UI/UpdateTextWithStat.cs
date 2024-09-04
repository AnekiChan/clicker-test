using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateTextWithStat : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] string _textFormat = "Coins: {0}";
    void OnEnable()
    {
        CoinStats.OnChangeCoins += ChangeText;
    }
    void OnDisable()
    {
        CoinStats.OnChangeCoins -= ChangeText;
    }
    private void ChangeText(int value)
    {
        _text.text = string.Format(_textFormat, value);
    }
}
