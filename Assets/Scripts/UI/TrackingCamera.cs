using UnityEngine;

public class TrackingCamera : MonoBehaviour
{
    [SerializeField] private Transform _yobaPosition;
    private int _offset = 5;

    private void Update()
    {
        transform.position = new Vector3(_yobaPosition.position.x + _offset, _yobaPosition.position.y, transform.position.z);
    }
}
