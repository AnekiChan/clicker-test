using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesManager: MonoBehaviour
{
    [SerializeField] CoinStats _coinStats;
    [SerializeField] private float _priceMultiplier = 5f;
    [SerializeField] private Dictionary<Stat, int> _statsAndPrices = new Dictionary<Stat, int>();

    public void TryToUpgrade(Stat stat)
    {
        // pass
        CommonEvents.Instance.OnStatUpgraded?.Invoke(stat);
    }

    private int CalculateNewPrice(Stat stat)
    {
        return Mathf.RoundToInt(Mathf.Exp(stat.CurrentUpgradeLevel) * _priceMultiplier);
    }
}
