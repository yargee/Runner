using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [SerializeField] private Platform _template;
    [SerializeField] private Transform _yobaPosition;

    private int _maxPlatformHeight = 5;
    private int _minPlatformHeight = -4;
    private int _offset = 37;    

    public void SpawnPlatform()
    {
        Vector2 spawnPlace = new Vector2(_yobaPosition.position.x + _offset, transform.position.y + Random.Range(_minPlatformHeight, _maxPlatformHeight));
        Instantiate(_template, spawnPlace, Quaternion.identity);
    }     

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Platform platform))
        {
            SpawnPlatform();
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

