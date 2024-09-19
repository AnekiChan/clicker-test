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
    public Action<int> OnChangedCoins;
    public Action OnStatUpgraded; // действия после обновления статов

    public Action<int, int, int> OnLevelChanged; // действия на изменение уровня
    public Action<int> OnLevelPointsAdded; // действия на добавление очков уровня
}
