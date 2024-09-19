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

    private IEnumerator NumbersAnimation(float currentCoins, float addedCoins)
    {
        float time = 0;
        while (time < timeToMakeFull)
        {
            time += Time.deltaTime;
            _text.text = string.Format(_textFormat, Convert.ToInt32(Mathf.Lerp(currentCoins, currentCoins + addedCoins, time / timeToMakeFull)).ToString());
            yield return null;
        }
    }
}