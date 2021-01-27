using UnityEngine;
using UnityEngine.Events;

public class GroundDetection : MonoBehaviour
{
    public event UnityAction GroundLost;
    public event UnityAction GroundFound;   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Platform platform))
        {
            GroundFound?.Invoke();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Platform platform))
        {
            GroundLost?.Invoke();
        }
    }
}
