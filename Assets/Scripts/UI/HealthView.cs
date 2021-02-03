using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Image[] _health;
    [SerializeField] private Yoba _yoba;

    private void OnEnable()
    {
        _yoba.HealthPointsChanged += OnHealthPointsChanged;
    }

    private void OnDisable()
    {
        _yoba.HealthPointsChanged -= OnHealthPointsChanged;
    }

    private void OnHealthPointsChanged(int healthPoints)
    {
        _health[healthPoints].gameObject.SetActive(false);
    }
}
