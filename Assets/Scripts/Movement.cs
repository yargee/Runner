using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(GroundDetection))]
public class Movement : MonoBehaviour
{
    private Animator _animator;
    private GroundDetection _groundDetection;
    private Rigidbody2D _rigidbody;
    private Vector2 _moveDirection = Vector2.right;
    private Vector2 _jumpDirection = Vector2.up;
    private float _speed = 8;
    private float _jumpForce = 12;
    private float _energy = 5;    
    public event UnityAction<float> EnergyChanged;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _groundDetection = GetComponent<GroundDetection>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _groundDetection.GroundLost += OnGroundLost;
        _groundDetection.GroundFound += OnGroundFound;
    }

    private void OnDisable()
    {
        _groundDetection.GroundLost -= OnGroundLost;
        _groundDetection.GroundFound -= OnGroundFound;
    }   

    private void Update()
    {        
        Move();
        Jump();
    }

    private void OnGroundLost()
    {
        _animator.SetBool("IsGrounded", false);
    }

    private void OnGroundFound()
    {
        _animator.SetBool("IsGrounded", true);
    }

    private void Move()
    {
        transform.Translate(_moveDirection * _speed * Time.deltaTime);
        if (_energy <= 10)
        {
            float changeValue = Time.deltaTime * 1.5f;
            _energy += changeValue;
            EnergyChanged?.Invoke(_energy);
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_energy >= 1.5f)
            {
                _rigidbody.AddForce(_jumpDirection * _jumpForce, ForceMode2D.Impulse);
                _energy -= 1.5f;
                EnergyChanged?.Invoke(_energy);
            }
        }
    }
}
