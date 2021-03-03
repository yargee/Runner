using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(DeathChecker))]
[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Inventory))]
public class Yoba : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _image;
    [SerializeField] private DeathChecker _deathChecker;
    [SerializeField] private Movement _mover;
    [SerializeField] private Health _health;
    [SerializeField] private Inventory _inventory;
    
    public event UnityAction<int, Coin> CoinCollected;
    public event UnityAction HealthPointsChanged;

    private void OnEnable()
    {
        _deathChecker.DeathPointReached += OnDeathPointReached;
    }

    private void OnDisable()
    {
        _deathChecker.DeathPointReached -= OnDeathPointReached;
    }
    
    private void FixedUpdate()
    {
        _mover.Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            _inventory.CollectCoin();
            CoinCollected?.Invoke(_inventory.Coins, coin);
        }

        if (collision.TryGetComponent(out Chair chair))
        {
            _health.TakeDamage(chair.Damage);
            HealthPointsChanged?.Invoke();
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

    public void OnDeathPointReached()
    {        
        _health.Die();
    }
}
