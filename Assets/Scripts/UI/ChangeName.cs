using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeName : MonoBehaviour
{
    [SerializeField] private Text _text;

    void Start()
    {
        CommonEvents.Instance.OnLevelChanged += ChangeNameInText;
    }

    void OnDisable()
    {
        CommonEvents.Instance.OnLevelChanged -= ChangeNameInText;
    }

    private void ChangeNameInText(float level, float _pointsToUpdate, float currentPoints)
    {
        _text.text = Names.GetRandomName();
    }
}
