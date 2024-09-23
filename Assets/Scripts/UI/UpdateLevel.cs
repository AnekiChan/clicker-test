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
        CommonEvents.Instance.OnLevelChanged += ChangeLevelText;
        CommonEvents.Instance.OnClicked += ChangeProgressBar;
        CommonEvents.Instance.OnLevelPointsChaneged += ChangeProgressBar;
    }
    void OnDisable()
    {
        CommonEvents.Instance.OnLevelChanged -= ChangeLevelText;
        CommonEvents.Instance.OnClicked -= ChangeProgressBar;
        CommonEvents.Instance.OnLevelPointsChaneged -= ChangeProgressBar;
    }

    private void ChangeLevelText(float level, float _pointsToUpdate, float currentPoints)
    {
        _levelText.text = string.Format(_textFormat, level);
        _progressBar.maxValue = _pointsToUpdate;
        _progressBar.value = _pointsToUpdate;
    }

    private void ChangeProgressBar()
    {
        _progressBar.value = LevelSystem.CurrentPoints;
    }

}
