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
    void OnEnable()
    {
        _upgradedStat = GetComponent<Stat>();
        CommonEvents.Instance.OnStatUpgraded += ChangeText;
    }
    void OnDisable()
    {
        CommonEvents.Instance.OnStatUpgraded -= ChangeText;
    }
    private void ChangeText(Stat stat)
    {
        if (_upgradedStat == stat && stat.CanBeUpgraded)
        {
            if (stat.CurrentUpgradeLevel == stat.MaxUpgradeLevel)
            {
                _text.text = string.Format(_textFormat, stat.CurrentStatValue);
                CommonEvents.Instance.OnStatUpgraded -= ChangeText;
                _buyButton.SetActive(false);
            }
            else
            {
                _text.text = string.Format(_textFormat, stat.CurrentStatValue);
                _priceText.text = stat.UpgradePrice.ToString();
            }
        }
    }
}
