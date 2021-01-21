using UnityEngine;
using UnityEngine.Events;

public class PlatformDeactivator : MonoBehaviour
{
    public event UnityAction NeedNewPlatform;
    public event UnityAction DeactivatePlatform;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Platform platform))
        {
            NeedNewPlatform?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Platform platform))
        {
            DeactivatePlatform?.Invoke();
        }
    }
}
