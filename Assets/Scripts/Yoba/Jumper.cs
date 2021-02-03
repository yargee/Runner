using UnityEngine;
using UnityEngine.Events;

public class Jumper : MonoBehaviour
{
    private const string IsGrounded = "IsGrounded";

    [SerializeField] private Energy _energy;

    private Animator _animator;
    private GroundDetection _groundDetection;
    private Rigidbody2D _rigidbody;
    private Vector2 _jumpDirection = Vector2.up;
    private float _jumpForce = 12;
    private YobaInput _yobaInput;

    public event UnityAction YobaJumped;

    private void Awake()
    {
        _yobaInput = new YobaInput();
        _yobaInput.Yoba.Jump.performed += context => OnJumpPerformed();
        _animator = GetComponent<Animator>();
        _groundDetection = GetComponent<GroundDetection>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _yobaInput.Enable();
        _groundDetection.GroundedStatusChanged += OnGroundedStatusChanged;
    }

    private void OnDisable()
    {
        _yobaInput.Disable();
        _groundDetection.GroundedStatusChanged -= OnGroundedStatusChanged;
        _yobaInput.Yoba.Jump.performed -= context => OnJumpPerformed();
    }

    private void OnGroundedStatusChanged(bool value)
    {
        _animator.SetBool(IsGrounded, value);
    }

    public void OnJumpPerformed()
    {
        if (_energy.Value >= 1.5f)
        {
            YobaJumped?.Invoke();
            _rigidbody.AddForce(_jumpDirection * _jumpForce, ForceMode2D.Impulse);
        }
    }
}
