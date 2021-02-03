using UnityEngine;

public class PlatformLauncher : MonoBehaviour
{    
    [SerializeField] private Platform _template;
    [SerializeField] private Transform _yobaPosition;  
    
    private int _maxPlatformHeight = 5;
    private int _minPlatformHeight = -4;
    private int _offset = 27;    

    private void Update()
    {
        transform.position = new Vector2(_yobaPosition.position.x + _offset, transform.position.y);
    }

    public void SpawnPlatform()
    {
        Vector2 spawnPlace = new Vector2(transform.position.x, transform.position.y + Random.Range(_minPlatformHeight, _maxPlatformHeight));
        Instantiate(_template, spawnPlace, Quaternion.identity);
    }
}
