using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    [SerializeField] private CoinStats _coinStats;
    [SerializeField] private float _multiplier = 10f;

    private static float _currentPoints = 0;
    public static float CurrentPoints => _currentPoints;
    private int _currentLevel = 1;
    private int _pointsToUpdate;

    void OnEnable()
    {
        CommonEvents.Instance.OnLevelPointsAdded += AddPoints;
    }
    void OnDisable()
    {
        CommonEvents.Instance.OnLevelPointsAdded -= AddPoints;
    }
    void Start()
    {
        CalculatePoitsForNewLevel();
        CommonEvents.Instance.OnLevelChanged?.Invoke(_currentLevel, _pointsToUpdate, _currentPoints);
    }

    private void CalculatePoitsForNewLevel()
    {
        _pointsToUpdate = Mathf.FloorToInt(Mathf.Exp(_currentLevel) * _multiplier);
    }

    // добавляем монеты как очки опыта
    private void AddPoints(float coins)
    {
        _currentPoints += coins;
        CommonEvents.Instance.OnLevelPointsChaneged?.Invoke();
        if (_currentPoints >= _pointsToUpdate)
        {
            _currentLevel++;
            _currentPoints -= _pointsToUpdate;
            CalculatePoitsForNewLevel();
            CommonEvents.Instance.OnLevelChanged?.Invoke(_currentLevel, _pointsToUpdate, _currentPoints);
        }
    }
}
