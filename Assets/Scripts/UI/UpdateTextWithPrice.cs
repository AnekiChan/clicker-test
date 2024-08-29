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
    private UpgradeStat _upgradeStat;
    void OnEnable()
    {
        _upgradeStat = GetComponent<UpgradeStat>();
        ClickerStats.OnStatUpgraded += ChangeText;
        _upgradeStat.OnPriceChanged += ChangePrice;
    }
    void OnDisable()
    {
        ClickerStats.OnStatUpgraded -= ChangeText;
        _upgradeStat.OnPriceChanged -= ChangePrice;
    }
    private void ChangeText(StatsToUpgrade stat, int currentStat, bool isLastUpgrade)
    {
        if (_upgradeStat.Stat == stat)
        {
            _text.text = string.Format(_textFormat, currentStat);
            Debug.Log("Is last upgrade " + isLastUpgrade);
            if (isLastUpgrade)
            {
                ClickerStats.OnStatUpgraded -= ChangeText;
                _upgradeStat.OnPriceChanged -= ChangePrice;
                _buyButton.SetActive(false);
            }
        }
    }
    
    private void ChangePrice(int price)
    {
        _priceText.text = price.ToString();
    }
}
