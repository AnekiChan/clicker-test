using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Stats;

public class CoinStats : MonoBehaviour
{
    private int _currentCoins = 0;
    public int CurrentCoins => _currentCoins;

    public void ChangeCoinsValue(int coins)
    {
        _currentCoins += coins;
        CommonEvents.Instance.OnLevelPointsAdded?.Invoke(coins);
        CommonEvents.Instance.OnChangedCoins?.Invoke(_currentCoins);
    }

    public void RemoveCoins(int coins)
    {
        _currentCoins -= coins;
        CommonEvents.Instance.OnChangedCoins?.Invoke(_currentCoins);
    }
}
