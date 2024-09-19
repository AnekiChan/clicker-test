using System.Collections;
using System.Collections.Generic;
using Stats;
using UnityEngine;
using UnityEngine.UI;

public class UpdateTextWithPrice : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] string _textFormat = "Coins: {0}";
    [SerializeField] private Text _priceText;
    [SerializeField] private GameObject _buyButton;
    private Stat _upgradedStat;
    void Start()
    {
        _upgradedStat = GetComponent<Stat>();
        CommonEvents.Instance.OnStatUpgraded += ChangeText;
        ChangeText();
    }
    void OnDisable()
    {
        CommonEvents.Instance.OnStatUpgraded -= ChangeText;
    }
    private void ChangeText()
    {
        if (_upgradedStat == null) return;
        if (_upgradedStat.CurrentUpgradeLevel == _upgradedStat.MaxUpgradeLevel)
        {
            _text.text = string.Format(_textFormat, _upgradedStat.CurrentStatValue);
            CommonEvents.Instance.OnStatUpgraded -= ChangeText;
            _buyButton.SetActive(false);
        }
        else
        {
            _text.text = string.Format(_textFormat, _upgradedStat.CurrentStatValue);
            _priceText.text = _upgradedStat.UpgradePrice.ToString();
        }

    }
}
