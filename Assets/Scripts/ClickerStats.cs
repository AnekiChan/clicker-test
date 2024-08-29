using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Stats;

public class ClickerStats : MonoBehaviour
{
    public static Action OnClicked;
    public static Action<int> OnChangeCoins;
    public static Action<StatsToUpgrade, int, int, bool> OnChangeStats;
    public static Action<StatsToUpgrade, int, bool> OnStatUpgraded;

    private static int _currentCoins = 0;
    public static int CurrentCoins => _currentCoins;
    // монеты в сек
    private static int _coinsPerClick = 1;
    public static int CoinsPerClick => _coinsPerClick;
    [SerializeField] private float _coinsPerClickMultiplier = 10f;
    // автоклик
    [SerializeField] private int _maxTimerForAutoCkick = 10;
    private int _minTimerForAutoCkick = 1;
    private int _currentTimerForAutoCkick;

    private void OnEnable()
    {
        OnClicked += Click;
        OnChangeStats += ChangeStats;
    }
    
    private void OnDisable()
    {
        OnClicked -= Click;
        OnChangeStats -= ChangeStats;
    }

    private void Start()
    {
        _currentTimerForAutoCkick = _maxTimerForAutoCkick;
        StartCoroutine(Autoclick());
    }

    private void Click()
    {
        _currentCoins += _coinsPerClick;
        OnChangeCoins?.Invoke(_currentCoins);
    }

    private IEnumerator Autoclick()
    {
        while (true)
        {
            yield return new WaitForSeconds(_currentTimerForAutoCkick);
            OnClicked?.Invoke();
            OnChangeCoins?.Invoke(_currentCoins);
        }
    }

    public void ChangeStats(StatsToUpgrade stats, int upgradeLevel, int price, bool isLastUpgrade)
    {
        if (price <= _currentCoins)
        {
            _currentCoins -= price;
            OnChangeCoins?.Invoke(_currentCoins);
            switch (stats)
            {
            case StatsToUpgrade.CoinsPerClick:
                {
                    _coinsPerClick = Mathf.RoundToInt(Mathf.Exp(upgradeLevel) * _coinsPerClickMultiplier);
                    OnStatUpgraded?.Invoke(StatsToUpgrade.CoinsPerClick, _coinsPerClick, isLastUpgrade);
                    Debug.Log($"Coins per click chaneged: {_coinsPerClick}");
                }
                break;
            case StatsToUpgrade.TimerForAutoClick:
                {
                    if ((_maxTimerForAutoCkick - upgradeLevel) >= _minTimerForAutoCkick) 
                    {  
                        _currentTimerForAutoCkick = _maxTimerForAutoCkick - upgradeLevel;
                        OnStatUpgraded?.Invoke(StatsToUpgrade.TimerForAutoClick, _currentTimerForAutoCkick, isLastUpgrade);
                        Debug.Log($"Timer for autoclick chaneged: {_currentTimerForAutoCkick}");
                    }
                }
                break;
            }
        }
    }
}
