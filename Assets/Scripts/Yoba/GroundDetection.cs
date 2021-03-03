using UnityEngine;
using UnityEngine.Events;

public class GroundDetection : MonoBehaviour
{
    public event UnityAction<bool> GroundedStatusChanged;      

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Platform platform))
        {
            GroundedStatusChanged?.Invoke(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Platform platform))
        {
            GroundedStatusChanged?.Invoke(false);
        }
    }
}
