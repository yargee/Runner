using UnityEngine;
using UnityEngine.Events;

public class PlatformPositionChecker : MonoBehaviour
{
    [SerializeField] private Transform _yobaPosition;
    public event UnityAction NewPlatformNeeding;
    private int _offset = -20;

    private void Update()
    {
        transform.position = new Vector2(_yobaPosition.position.x + _offset, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Platform platform))
        {
            NewPlatformNeeding?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Platform platform))
        {
            platform.Selfdestruct();
        }
    }
}
