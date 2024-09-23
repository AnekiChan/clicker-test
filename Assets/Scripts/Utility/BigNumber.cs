using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Stats;

public class BigNumber
{
    private float _currentNumber = 0;
    public float CurrentNumber => _currentNumber;

    private string[] _prefix = { "", "K", "M", "B", "T" };
    private int _prefixIndex = 0;
    public string Prefix => _prefix[_prefixIndex];

    public BigNumber()
    {
        _currentNumber = 0;
    }

    public void UpdateNumber(float newValue)
    {
        _currentNumber = newValue;
        CheackPrefix();
    }

    private void CheackPrefix()
    {
        if (_currentNumber >= 1000)
        {
            _prefixIndex = 0;
            while (_currentNumber >= 1000)
            {
                _prefixIndex++;
                _currentNumber /= 1000;
            }
        }
        else _prefixIndex = 0;
    }

    public float GetDivision()
    {
        switch (_prefixIndex)
        {
            case 0:
                return 1;
            case 1:
                return 1000;
            case 2:
                return 1000000;
            case 3:
                return 1000000000;
            case 4:
                return 1000000000000;
            default:
                return 1;
        }
    }

    public string FormatNumber()
    {
        if (_prefixIndex == 0) return _currentNumber.ToString("0");
        else return _currentNumber.ToString("0.00") + Prefix;
    }

    public string FormatNumber(float num)
    {
        if (_prefixIndex == 0) return num.ToString("0");
        else return num.ToString("0.00") + Prefix;
    }
}