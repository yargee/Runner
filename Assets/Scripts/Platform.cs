using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Platform : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _color;
    [SerializeField] private List<Chair> _chairs;
    [SerializeField] private List<Coin> _coins;

    private void OnEnable()
    {
        _color.color = Random.ColorHSV();
        SetObjectsOnPlatform(_chairs);
        SetObjectsOnPlatform(_coins);
    }

    public void Selfdestruct()
    {
        Destroy(gameObject);
    }

    private void SetObjectsOnPlatform(IEnumerable<IPlatformSettable> list)
    {
        foreach (var item in list)
        {
            item.TrySetActive();
        }
    }
}