using UnityEngine;

public class TrackingCamera : MonoBehaviour
{
    [SerializeField] private Transform _yoba;

    private int _offset = 5;

    private void Update()
    {
        transform.position = new Vector3(_yoba.position.x + _offset, _yoba.position.y, transform.position.z);
    }
}
