using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Stats;

public class CoinStats : MonoBehaviour
{
    private float _currentCoins = 0;
    public float CurrentCoins => _currentCoins;


    public void ChangeCoinsValue(float coins)
    {
        _currentCoins += coins;

        CommonEvents.Instance.OnCoinsAdded?.Invoke(_currentCoins, coins);
        CommonEvents.Instance.OnLevelPointsAdded?.Invoke(coins);
        CommonEvents.Instance.OnChangedCoins?.Invoke(_currentCoins);
    }

    public void RemoveCoins(float coins)
    {
        _currentCoins -= coins;

        CommonEvents.Instance.OnCoinsAdded?.Invoke(_currentCoins, -coins);
        CommonEvents.Instance.OnChangedCoins?.Invoke(_currentCoins);
    }

}
