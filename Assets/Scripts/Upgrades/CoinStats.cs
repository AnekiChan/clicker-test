using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Stats;

public class CoinStats : MonoBehaviour
{
    // public static Action OnClicked;
    // public static Action<int> OnChangeCoins;
    // public static Action<StatsToUpgrade, int, int, bool> OnChangeStats;
    // public static Action<StatsToUpgrade, int, bool> OnStatUpgraded;

    private static int _currentCoins = 0;
    public static int CurrentCoins => _currentCoins;
    // монеты в сек
    // private static int _coinsPerClick = 1;
    // public static int CoinsPerClick => _coinsPerClick;
    // [SerializeField] private float _coinsPerClickMultiplier = 10f;
    // автоклик
    // [SerializeField] private int _maxTimerForAutoCkick = 10;
    // private int _minTimerForAutoCkick = 1;
    // private int _currentTimerForAutoCkick;

    private void OnEnable()
    {
        CommonEvents.Instance.OnChangeStats += ChangeStats;
    }
    
    private void OnDisable()
    {
        CommonEvents.Instance.OnChangeStats -= ChangeStats;
    }

    public void ChangeCoinsValue(int coins)
    {
        _currentCoins += coins;
        CommonEvents.Instance.OnChangedCoins?.Invoke(_currentCoins);
    }

    public void ChangeStats(Stat stat, int price)
    {
        if (price <= _currentCoins)
        {
            _currentCoins -= price;
            CommonEvents.Instance.OnChangedCoins?.Invoke(_currentCoins);
            stat.ApplyUpgrade();
        }
    }
}
