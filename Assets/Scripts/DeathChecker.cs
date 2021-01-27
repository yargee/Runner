using UnityEngine;
using UnityEngine.Events;

public class DeathChecker : MonoBehaviour
{
    [SerializeField] Transform _deathPoint;
    [SerializeField] Yoba _yoba;
    public event UnityAction YobaDead;
    private int _healthpoint = 5;

    private void OnEnable()
    {
        _yoba.HealthPointsChanged += OnHealthPointchanged;
    }

    private void OnDisable()
    {
        _yoba.HealthPointsChanged -= OnHealthPointchanged;
    }

    private void Update()
    {
        if (_yoba.transform.position.y < _deathPoint.position.y)
        {
            YobaDead?.Invoke();
        }
    }

    private void OnHealthPointchanged(int value)
    {
        _healthpoint--;
        if(_healthpoint == 0)
        {
            YobaDead?.Invoke();
        }
    }
}
