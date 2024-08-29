using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Stats;
using System;

public class UpgradeStat : MonoBehaviour
{
    public Action<int> OnPriceChanged;
    [SerializeField] private StatsToUpgrade _stat;
    public StatsToUpgrade Stat => _stat;
    private int _currentUpgradeLevel = 0;
    [SerializeField] bool _hasMaxUpgradeLevel = false;
    [SerializeField] private int _maxUpgradeLevel = 10;
    private int _currentPrice = 0;
    private float _multiplier = 5f;

    void Start()
    {
        CalculatePrice();
    }
    
    private void CalculatePrice()
    {
        _currentPrice = Mathf.RoundToInt(Mathf.Exp(_currentUpgradeLevel) * _multiplier);
        OnPriceChanged?.Invoke(_currentPrice);
    }
    public void Upgrade()
    {
        if (ClickerStats.CurrentCoins >= _currentPrice)
        {
            _currentUpgradeLevel++;
            ClickerStats.OnChangeStats?.Invoke(_stat, _currentUpgradeLevel, _currentPrice, _hasMaxUpgradeLevel && ((_maxUpgradeLevel - 1) <= _currentUpgradeLevel));
            CalculatePrice();
        }
    }
}
