using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Stats;

public class CoinStats : MonoBehaviour
{
    private float _currentCoins = 0;
    public float CurrentCoins => _currentCoins;

    private BigNumber _bigNumber = new BigNumber();

    public void ChangeCoinsValue(float coins)
    {
        _currentCoins += coins;
        _bigNumber.UpdateNumber(_currentCoins);

        CommonEvents.Instance.OnCoinsAdded?.Invoke(_bigNumber, coins);
        Debug.Log(_bigNumber.CurrentNumber);

        CommonEvents.Instance.OnLevelPointsAdded?.Invoke(coins);
        CommonEvents.Instance.OnChangedCoins?.Invoke(_currentCoins);
    }

    public void RemoveCoins(float coins)
    {
        _currentCoins -= coins;
        _bigNumber.UpdateNumber(_currentCoins);

        CommonEvents.Instance.OnCoinsAdded?.Invoke(_bigNumber, -coins);
        CommonEvents.Instance.OnChangedCoins?.Invoke(_currentCoins);
    }

}
