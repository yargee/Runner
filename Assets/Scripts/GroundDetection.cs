using UnityEngine;

public class GroundDetection : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] bool _isGrounded = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Platform platform))
        {
            _isGrounded = true;
            _animator.SetBool("IsGrounded", true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Platform platform))
        {
            _isGrounded = false;
            _animator.SetBool("IsGrounded", false);
        }
    }
}
