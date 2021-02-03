using UnityEngine;
using UnityEngine.Events;

public class Movement : MonoBehaviour
{
    private Vector2 _moveDirection = Vector2.right;
    private float _speed = 7;

    public void Move()
    {
        transform.Translate(_speed * _moveDirection * Time.deltaTime);
    }
}
