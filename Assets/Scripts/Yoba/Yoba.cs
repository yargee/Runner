using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(DeathChecker))]
[RequireComponent(typeof(Movement))]
public class Yoba : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _image;
    [SerializeField] private DeathChecker _deathChecker;
    [SerializeField] private Movement _mover;    

    private int _healthPoints = 5;
    private int _coins = 0;
    private bool _alive = true;

    public event UnityAction<int, Coin> CoinCollected;
    public event UnityAction<int> HealthPointsChanged;

    public bool Alive => _alive;

    private void OnEnable()
    {
        _deathChecker.YobaDied += OnYobaDied;
    }

    private void OnDisable()
    {
        _deathChecker.YobaDied -= OnYobaDied;
    }

    private void Update()
    {
        _mover.Move();        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            _coins++;
            CoinCollected?.Invoke(_coins, coin);
        }

        if (collision.TryGetComponent(out Chair chair))
        {
            _healthPoints--;
            HealthPointsChanged?.Invoke(_healthPoints);
            _image.color = Color.red;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Chair chair))
        {
            _image.color = new Color(255, 255, 255, 255);
        }
    }

    public void OnYobaDied()
    {
        _alive = false;
        gameObject.SetActive(false);
    }
}
