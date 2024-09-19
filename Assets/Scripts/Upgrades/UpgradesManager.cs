using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesManager: MonoBehaviour
{
    [SerializeField] CoinStats _coinStats;
    [SerializeField] private List<Stat> _stats = new List<Stat>();

    private void Start()
    {
        foreach (Stat stat in _stats)
        {
            CommonEvents.Instance.OnStatUpgraded?.Invoke(stat);
        }
    }

    public void TryToUpgrade(Stat stat)
    {
        int idx = _stats.IndexOf(stat);
        if (idx != -1)
        {
            if (_coinStats.CurrentCoins >= stat.UpgradePrice)
            {
                _coinStats.RemoveCoins(stat.UpgradePrice);
                stat.ApplyUpgrade();
                CommonEvents.Instance.OnStatUpgraded?.Invoke(stat);
            }
            else Debug.Log("Not enough coins");
        }
        else Debug.LogError("Stat not found");
    }
}
