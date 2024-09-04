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
    public Action<Stat, int> OnChangeStats;
    public Action<Stat> OnStatUpgraded;
}
