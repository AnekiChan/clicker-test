using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateAutoclickBar : MonoBehaviour
{
    [SerializeField] private Slider _progressBar;

    private void Start()
    {
        _progressBar.value = 0;
        CommonEvents.Instance.OnAutoclickTimerStart += StartProgressBar;
    }

    private void OnDisable()
    {
        CommonEvents.Instance.OnAutoclickTimerStart -= StartProgressBar;
    }

    private void StartProgressBar(int timeToMakeFull)
    {
        _progressBar.value = 0;
        StartCoroutine(ProgressBarAnimation(timeToMakeFull));
    }

    private IEnumerator ProgressBarAnimation(int timeToMakeFull)
    {
        float time = 0;
        while (time < timeToMakeFull)
        {
            time += Time.deltaTime;
            _progressBar.value = time / timeToMakeFull;
            yield return null;
        }
    }
}
