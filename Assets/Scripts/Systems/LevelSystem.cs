using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    public static Action<int, int> OnLevelChanged;
    private int _currentLevel = 1;
    private static int _currentPoints = 0;
    public static int CurrentPoints => _currentPoints;
    private int _pointsToUpdate;
    [SerializeField] private float _multiplier = 10f;

    void OnEnable()
    {
        CoinStats.OnClicked += AddPoints;
    }
    void OnDisable()
    {
        CoinStats.OnClicked -= AddPoints;
    }
    void Start()
    {
        CalculatePoitsForNewLevel();
        OnLevelChanged?.Invoke(_currentLevel, _pointsToUpdate);
    }

    private void CalculatePoitsForNewLevel()
    {
        _pointsToUpdate = Mathf.FloorToInt(Mathf.Exp(_currentLevel) * _multiplier);
    }

    // добавляем монетыкак очки опыта
    private void AddPoints()
    {
        _currentPoints += CoinStats.CoinsPerClick;
        if (_currentPoints >= _pointsToUpdate)
        {
            _currentLevel++;
            CalculatePoitsForNewLevel();
            OnLevelChanged?.Invoke(_currentLevel, _pointsToUpdate);
            _currentPoints = 0;
        }
    }
}
