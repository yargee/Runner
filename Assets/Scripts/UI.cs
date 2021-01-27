using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Slider _energyView;
    [SerializeField] private TMP_Text _coinsView;
    [SerializeField] private Image[] _health;
    [SerializeField] private Yoba _yoba;
    [SerializeField] private Movement _movement;
    [SerializeField] private DeathChecker _deathChecker;

    private void OnEnable()
    {
        _yoba.CoinCollected += OnCoinCollected;
        _yoba.HealthPointsChanged += OnHealthPointsChanged;
        _movement.EnergyChanged += OnEnergyChanged;
        _deathChecker.YobaDead += OnYobaDead;
    }

    private void OnDisable()
    {
        _yoba.CoinCollected -= OnCoinCollected;
        _yoba.HealthPointsChanged -= OnHealthPointsChanged;
        _movement.EnergyChanged -= OnEnergyChanged;
        _deathChecker.YobaDead -= OnYobaDead;
    }

    private void Start()
    {
        _yoba = GetComponent<Yoba>();
        _movement = GetComponent<Movement>();
    }

    private void OnCoinCollected(int coins, Coin coin)
    {
        _coinsView.text = coins.ToString();
        coin.gameObject.SetActive(false);
    }

    private void OnHealthPointsChanged(int healthPoints)
    {
        _health[healthPoints].gameObject.SetActive(false);
    }

    private void OnEnergyChanged(float value)
    {
        _energyView.value = value;
    }

    private void OnYobaDead()
    {
        Time.timeScale = 0;
    }
}
