using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateLevel : MonoBehaviour
{
    [SerializeField] private Slider _progressBar;
    [SerializeField] private Text _levelText;
    [SerializeField] private string _textFormat = "lvl.{0}";

    void OnEnable()
    {
        LevelSystem.OnLevelChanged += ChangeLevelText;
        CoinStats.OnClicked += ChangeProgressBar;
    }
    void OnDisable()
    {
        LevelSystem.OnLevelChanged -= ChangeLevelText;
        CoinStats.OnClicked -= ChangeProgressBar;
    }

    private void ChangeLevelText(int level, int _pointsToUpdate)
    {
        _levelText.text = string.Format(_textFormat, level);
        _progressBar.value = 0;
        _progressBar.maxValue = _pointsToUpdate;
    }

    private void ChangeProgressBar()
    {
        _progressBar.value = LevelSystem.CurrentPoints;
    }

}
