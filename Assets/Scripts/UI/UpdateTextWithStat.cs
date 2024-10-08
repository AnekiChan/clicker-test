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
        CommonEvents.Instance.OnChangedCoins += ChangeText;
    }
    void OnDisable()
    {
        CommonEvents.Instance.OnChangedCoins -= ChangeText;
    }
    private void ChangeText(float value)
    {
        _text.text = string.Format(_textFormat, value);
    }
}
