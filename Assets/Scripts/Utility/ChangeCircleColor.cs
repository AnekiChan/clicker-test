using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCircleColor : MonoBehaviour
{
    void OnEnable()
    {
        LevelSystem.OnLevelChanged += ChangeColor;
    }

    void OnDisable()
    {
        LevelSystem.OnLevelChanged -= ChangeColor;
    }

    private void ChangeColor(int level, int _pointsToUpdate)
    {
        GetComponent<SpriteRenderer>().color = new Color(Random.Range(0.5f, 1f), Random.Range(0.5f, 1f), Random.Range(0.5f, 1f), 1f);
    }
}
