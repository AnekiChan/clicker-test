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
        //_upgradedStat = GetComponent<UpgradeStat>();
        CoinStats.OnStatUpgraded += ChangeText;
        //_upgradeStat.OnPriceChanged += ChangePrice;
    }
    void OnDisable()
    {
        CoinStats.OnStatUpgraded -= ChangeText;
        //_upgradeStat.OnPriceChanged -= ChangePrice;
    }
    private void ChangeText(Stat stat)
    {
        if (_upgradedStat == stat)
        {
            _text.text = string.Format(_textFormat, stat.CurrentStatValue);
            Debug.Log("Is last upgrade " + ());
            if (isLastUpgrade)
            {
                CoinStats.OnStatUpgraded -= ChangeText;
                _upgradedStat.OnPriceChanged -= ChangePrice;
                _buyButton.SetActive(false);
            }
        }
    }
    
    private void ChangePrice(int price)
    {
        _priceText.text = price.ToString();
    }
}
