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
        SetObjectsOnPlatform(_platformObjects);        
    }

    public void Selfdestruct()
    {
        Destroy(gameObject);
    }

    private void SetObjectsOnPlatform(List<PlatformObject> list)
    {
        foreach (var item in list)
        {
            if(item is Coin)
            {
                item.TryEnable(70);
            }    
            else
            {
                item.TryEnable(60);
            }
        }
    }
}