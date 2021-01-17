using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] private List<Platform> _platformsPool;    
    [SerializeField] private Platform _currentPlatform;    

    private Platform _platformToDeactivate;

    public void OnNeedNewPlatform()
    {        
        int nextIndex = Random.Range(0, _platformsPool.Count);

        _platformsPool[nextIndex].transform.position = new Vector2(transform.position.x, transform.position.y + Random.Range(-4, 5));
        _platformsPool[nextIndex].gameObject.SetActive(true);
        _platformToDeactivate = _currentPlatform;        
        _currentPlatform = _platformsPool[nextIndex];        
        _platformsPool.RemoveAt(nextIndex);       
    }

    public void OnDeactivatePlatform()
    {                
        _platformToDeactivate.gameObject.SetActive(false);
        _platformToDeactivate.transform.position = transform.position;
        _platformsPool.Add(_platformToDeactivate);
    }
}
