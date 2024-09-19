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
    }
    void OnDisable()
    {
        CommonEvents.Instance.OnLevelChanged -= ChangeLevelText;
        CommonEvents.Instance.OnClicked -= ChangeProgressBar;
    }

    private void ChangeLevelText(int level, int _pointsToUpdate, int currentPoints)
    {
        _levelText.text = string.Format(_textFormat, level);
        _progressBar.maxValue = _pointsToUpdate;
        //_progressBar.value = currentPoints;
        _progressBar.value = 0;
    }

    private void ChangeProgressBar()
    {
        _progressBar.value = LevelSystem.CurrentPoints;
    }

}
