using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCircleColor : MonoBehaviour
{
    void Start()
    {
        CommonEvents.Instance.OnLevelChanged += ChangeColor;
    }

    void OnDisable()
    {
        CommonEvents.Instance.OnLevelChanged -= ChangeColor;
    }

    private void ChangeColor(int level, int _pointsToUpdate, int currentPoints)
    {
        GetComponent<SpriteRenderer>().color = new Color(Random.Range(0.5f, 1f), Random.Range(0.5f, 1f), Random.Range(0.5f, 1f), 1f);
    }
}
