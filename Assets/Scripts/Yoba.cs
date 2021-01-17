using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;

public class Yoba : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _moveSpeed;    
    [SerializeField] private Slider _jumpEnergyView;
    [SerializeField] private TMP_Text _coinsView;    
    [SerializeField] private SpriteRenderer _image;    
    [SerializeField] Animator _animator;
    [SerializeField] Image[] _health;

    private int _healthPoints = 5;
    private Vector2 _jumpDirection = new Vector2(0, 1);
    private float _jumpEnergy = 5;
    private int _coins = 0;

    public UnityEvent CoinCollected;
    public UnityEvent YobaIsDead;

    public void ResetCoins()
    {
        _coins = 0;
    }

    public void OnYobaIsDead()
    {
        ResetCoins();
        Time.timeScale = 0;
    }

    public void OnCoinCollected()
    {
        _coins += 1;
        _coinsView.text = _coins.ToString();
        _image.color = new Color(255, 255, 255, 255);
    }    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Coin coin))
        {
            CoinCollected?.Invoke();
            coin.gameObject.SetActive(false);
        }

        if(collision.TryGetComponent(out Chair chair))
        {
            _image.color = Color.red;
            _healthPoints--;            
            _health[_healthPoints].gameObject.SetActive(false);
            if(_healthPoints == 0)
            {
                YobaIsDead?.Invoke();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Chair chair))
        {
            _image.color = new Color(255, 255, 255, 255);
        }
    }

    void Update()
    {       
        if (_jumpEnergy<=10)
        {
            _jumpEnergy += Time.deltaTime * 1.5f;
            _jumpEnergyView.value = Mathf.Round(_jumpEnergy);
        }        

        if (Input.GetKeyDown(KeyCode.Space))
        {      
            if(_jumpEnergy >=1.5f)
            {                
                _rigidbody.AddForce(_jumpDirection * _jumpForce, ForceMode2D.Impulse);
                _jumpEnergy -= 1.5f;                
            }            
        }        
    }
}
