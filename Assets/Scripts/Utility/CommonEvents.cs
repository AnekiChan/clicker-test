using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Stats;

public class CommonEvents : MonoBehaviour
{
    public static CommonEvents Instance;

    private void Awake()
    {
        Instance = this;
    }

    public Action OnClicked;
    public Action<float> OnChangedCoins;
    public Action<BigNumber, float> OnCoinsAdded;
    public Action OnStatUpgraded; // действия после обновления статов

    public Action<int> OnAutoclickTimerStart;

    public Action<float, float, float> OnLevelChanged; // действия на изменение уровня
    public Action<float> OnLevelPointsAdded; // действия на добавление очков уровня
    public Action OnLevelPointsChaneged;

    public Action OnPartclesStarted;
}
