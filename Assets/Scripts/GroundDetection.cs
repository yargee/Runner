using UnityEngine;

[RequireComponent(typeof(Animator))]
public class GroundDetection : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private bool _isGrounded = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Platform platform))
        {
            GroundDetectionSwitcher(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Platform platform))
        {
            GroundDetectionSwitcher(false);
        }
    }

    private void GroundDetectionSwitcher(bool value)
    {
        _isGrounded = value;
        _animator.SetBool("IsGrounded", value);
    }
}
