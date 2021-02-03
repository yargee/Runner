using UnityEngine;
using UnityEngine.Events;

public class DeathChecker : MonoBehaviour
{
    [SerializeField] private Transform _deathPoint;
    [SerializeField] private Yoba _yoba;

    private int _healthpoint = 5;

    public event UnityAction YobaDied;

    private void OnEnable()
    {
        _yoba.HealthPointsChanged += OnHealthPointsСhanged;
    }

    private void OnDisable()
    {
        _yoba.HealthPointsChanged -= OnHealthPointsСhanged;
    }

    private void Update()
    {
        if (_yoba.transform.position.y < _deathPoint.position.y && _yoba.Alive)
        {
            YobaDied?.Invoke();
        }
    }

    private void OnHealthPointsСhanged(int value)
    {
        _healthpoint--;
        if (_healthpoint == 0)
        {
            YobaDied?.Invoke();
        }
    }
}
