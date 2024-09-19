using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleClickChanceStat : Stat
{
    [SerializeField] private CoinsPerClickStat _coinsPerClickStat;

    [SerializeField] private CoinStats _coinStats;
    public override CoinStats CoinStats => _coinStats;

    [SerializeField] private float _chanceToDoubleClick = 0.1f;
    public override float CurrentStatValue => _chanceToDoubleClick;

    [SerializeField] private bool _canBeUpgraded = true;
    public override bool CanBeUpgraded => _canBeUpgraded;
    private int _currentUpgradeLevel = 0;
    public override int CurrentUpgradeLevel => _currentUpgradeLevel;
    [SerializeField] private int _maxUpgradeLevel = 10;
    public override int MaxUpgradeLevel => _maxUpgradeLevel;

    private int _upgradePrice = 0;
    public override int UpgradePrice => _upgradePrice;
    [SerializeField] private float _priceMultiplier = 5f;

    private void Start()
    {
        SetNewPrice();
        CommonEvents.Instance.OnClicked += DoubleClick;
    }

    private void OnDisable()
    {
        CommonEvents.Instance.OnClicked -= DoubleClick;
    }

    private void DoubleClick()
    {
        if (Random.Range(0f, 1f) < _chanceToDoubleClick)
        {
            _coinStats.ChangeCoinsValue(_coinsPerClickStat.CurrentStatValue);
            CommonEvents.Instance.OnPartclesStarted?.Invoke();
        }
    }
    public override void ApplyUpgrade()
    {
        _currentUpgradeLevel++;
        _chanceToDoubleClick += 0.1f;
        SetNewPrice();
        Debug.Log($"Chance to double click chaneged: {_chanceToDoubleClick}");
    }

    private void SetNewPrice()
    {
        _upgradePrice = Mathf.RoundToInt(Mathf.Exp(_currentUpgradeLevel) * _priceMultiplier);
    }
}
