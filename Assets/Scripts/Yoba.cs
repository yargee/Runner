using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Yoba : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Slider _jumpEnergyView;
    [SerializeField] private TMP_Text _coinsView;
    [SerializeField] private SpriteRenderer _image;
    [SerializeField] private Animator _animator;
    [SerializeField] private Image[] _health;
    [SerializeField] private Transform _deathChecker;
    private int _healthPoints = 5;
    private Vector2 _jumpDirection = new Vector2(0, 1);
    private float _jumpEnergy = 5;
    private int _coins = 0;
    public event UnityAction YobaIsDead;

    public void OnYobaIsDead()
    {
        _coins = 0;
        Time.timeScale = 0;
    }

    private void OnEnable()
    {
        YobaIsDead += OnYobaIsDead;
    }

    private void OnDisable()
    {
        YobaIsDead -= OnYobaIsDead;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            _coins += 1;
            _coinsView.text = _coins.ToString();
            coin.gameObject.SetActive(false);
        }

        if (collision.TryGetComponent(out Chair chair))
        {
            _image.color = Color.red;
            _healthPoints--;
            _health[_healthPoints].gameObject.SetActive(false);
            if (_healthPoints == 0)
            {
                YobaIsDead?.Invoke();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Chair chair))
        {
            _image.color = new Color(255, 255, 255, 255);
        }
    }

    void Update()
    {
        if (transform.position.y < _deathChecker.transform.position.y)
        {
            YobaIsDead?.Invoke();
        }

        if (_jumpEnergy <= 10)
        {
            _jumpEnergy += Time.deltaTime * 1.5f;
            _jumpEnergyView.value = _jumpEnergy;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_jumpEnergy >= 1.5f)
            {
                _rigidbody.AddForce(_jumpDirection * _jumpForce, ForceMode2D.Impulse);
                _jumpEnergy -= 1.5f;
            }
        }
    }
}
