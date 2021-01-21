using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [SerializeField] private List<Platform> _platformsPool;
    [SerializeField] private Platform _currentPlatform;
    [SerializeField] private PlatformDeactivator _triggerZone;
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

    private void OnEnable()
    {
        _triggerZone.NeedNewPlatform += OnNeedNewPlatform;
        _triggerZone.DeactivatePlatform += OnDeactivatePlatform;
    }

    private void OnDisable()
    {
        _triggerZone.NeedNewPlatform -= OnNeedNewPlatform;
        _triggerZone.DeactivatePlatform -= OnDeactivatePlatform;
    }
}
