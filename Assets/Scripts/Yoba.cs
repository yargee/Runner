using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class Yoba : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _image;
    private int _healthPoints = 5;
    private int _coins = 0;    
    public event UnityAction YobaDied;
    public event UnityAction<int, Coin> CoinCollected;
    public event UnityAction<int> HealthPointsChanged;

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
}
