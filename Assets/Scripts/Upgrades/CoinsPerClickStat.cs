using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Stats;
using Unity.VisualScripting;

public class CoinsPerClickStat : Stat
{
    [SerializeField] private CoinStats _coinStats;
    public override CoinStats CoinStats => _coinStats;

    private static int _coinsPerClick = 1;
    public override float CurrentStatValue => _coinsPerClick;

    [SerializeField] private bool _canBeUpgraded = true;
    public override bool CanBeUpgraded => _canBeUpgraded;
    private int _currentUpgradeLevel = 0;
    public override int CurrentUpgradeLevel => _currentUpgradeLevel;
    [SerializeField] private int _maxUpgradeLevel = 10;
    public override int MaxUpgradelevel => _maxUpgradeLevel;

    [SerializeField] private float _coinsPerClickMultiplier = 10f;

    private int _upgradePrice = 0;
    public override int UpgradePrice => _upgradePrice;

    private void Start()
    {
        //SetNewPrice();
    }
    private void OnEnable()
    {
        CommonEvents.Instance.OnClicked += Click;
    }
    
    private void OnDisable()
    {
        CommonEvents.Instance.OnClicked -= Click;
    }
    private void Click()
    {
        _coinStats.ChangeCoinsValue(_coinsPerClick);
    }
    
    public override void ApplyUpgrade()
    {
        _currentUpgradeLevel++;
        _coinsPerClick = Mathf.RoundToInt(Mathf.Exp(_currentUpgradeLevel) * _coinsPerClickMultiplier);
        //SetNewPrice();
        // CommonEvents.Instance.OnStatUpgraded?.Invoke(this);
        Debug.Log($"Coins per click chaneged: {_coinsPerClick}");
    }

    // private void SetNewPrice()
    // {
    //     _upgradePrice = Mathf.RoundToInt(Mathf.Exp(_currentUpgradeLevel) * _priceMultiplier);
    // }
}
