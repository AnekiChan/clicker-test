using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateNumbers : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] string _textFormat = "Coins: {0}";
    [SerializeField] private float timeToMakeFull = 0.5f;

    private BigNumber _bigNumber = new BigNumber();

    private void Start()
    {
        CommonEvents.Instance.OnCoinsAdded += StartUpdatingText;
    }

    private void OnDisable()
    {
        CommonEvents.Instance.OnCoinsAdded -= StartUpdatingText;
    }

    private void StartUpdatingText(float currentCoins, float addedCoins)
    {
        StartCoroutine(NumbersAnimation(currentCoins, addedCoins));
    }

    private IEnumerator NumbersAnimation(float currentBigNum, float addedCoins)
    {
        _bigNumber.UpdateNumber(currentBigNum);
        float time = 0;
        while (time < timeToMakeFull)
        {
            time += Time.deltaTime;
            _text.text = string.Format(_textFormat,
                _bigNumber.FormatNumber(
                Mathf.Lerp(_bigNumber.CurrentNumber - addedCoins / _bigNumber.GetDivision(), _bigNumber.CurrentNumber, time / timeToMakeFull)));
            yield return null;
        }
    }
}
