using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Stat : MonoBehaviour
{
    public abstract CoinStats CoinStats { get; }
    public abstract float CurrentStatValue { get; }
    public abstract bool CanBeUpgraded { get; }
    public abstract int CurrentUpgradeLevel { get; }
    public abstract int MaxUpgradelevel { get; }
    public abstract int UpgradePrice { get; }
    public abstract void ApplyUpgrade();
}
