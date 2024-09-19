using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Stats;

public class AutoclickStat : Stat
{
    [SerializeField] private CoinStats _coinStats;
    public override CoinStats CoinStats => _coinStats;

    private int _currentTimerForAutoClick;
    public override float CurrentStatValue => _currentTimerForAutoClick;
    [SerializeField] private bool _canBeUpgraded;
    public override bool CanBeUpgraded => _canBeUpgraded;
    [SerializeField] int _maxUpgradeLevel;
    public override int MaxUpgradeLevel => _maxUpgradeLevel;
    private int _currentUpgradeLevel = 0;
    public override int CurrentUpgradeLevel => _currentUpgradeLevel;

    [SerializeField] private int _maxTimerForAutoClick = 10;
    private int _minTimerForAutoClick = 1;

    // цена
    private int _upgradePrice = 0;
    public override int UpgradePrice => _upgradePrice;
    [SerializeField] private float _priceMultiplier = 5f;
    
    private void Start()
    {
        SetNewPrice();
        _currentTimerForAutoClick = _maxTimerForAutoClick;
        StartCoroutine(Autoclick());
    }
    
    private IEnumerator Autoclick()
    {
        while (true)
        {
            yield return new WaitForSeconds(_currentTimerForAutoClick);
            CommonEvents.Instance.OnClicked?.Invoke();
        }
    }
    
    public override void ApplyUpgrade()
    {
        if ((_maxTimerForAutoClick - _currentUpgradeLevel) >= _minTimerForAutoClick) 
        {  
            _currentUpgradeLevel++;
            _currentTimerForAutoClick = _maxTimerForAutoClick - _currentUpgradeLevel;
            SetNewPrice();
            Debug.Log($"Timer for autoclick chaneged: {_currentTimerForAutoClick}");
        }
    }

    private void SetNewPrice()
    {
        _upgradePrice = Mathf.RoundToInt(Mathf.Exp(_currentUpgradeLevel) * _priceMultiplier);
    }
}
