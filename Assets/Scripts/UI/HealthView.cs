using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Image[] _health;
    [SerializeField] private Yoba _yoba;
    private int index;

    private void OnEnable()
    {
        _yoba.HealthPointsChanged += OnHealthPointsChanged;
    }

    private void OnDisable()
    {
        _yoba.HealthPointsChanged -= OnHealthPointsChanged;
    }

    private void Start()
    {
        index = _health.Length -1;
    }

    private void OnHealthPointsChanged()
    {
        _health[index].gameObject.SetActive(false);
        index--;
    }
}
