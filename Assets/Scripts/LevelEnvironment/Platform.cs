using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Platform : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private List<PlatformObject> _platformObjects;

    private void OnEnable()
    {
        _renderer.color = Random.ColorHSV();
    }

    public void Selfdestruct()
    {
        Destroy(gameObject);
    }

    public void ActivatePlatformObjects()
    {
        foreach (var item in _platformObjects)
        {
            {
                item.TryEnable(item.SpawnChance);
            }
        }
    }
}