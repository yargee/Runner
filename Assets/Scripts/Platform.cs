using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class Platform : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private SpriteRenderer _color;
    [SerializeField] private List<Chair> _chairs;
    [SerializeField] private List<Coin> _topCoinsPool;
    [SerializeField] private List<Coin> _bottomCoinsPool;

    private void OnEnable()
    {
        _color.color = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);

        foreach (Chair chair in _chairs)
        {
            var isEnabled = Random.Range(0, 2) == 1 ? true : false;
            chair.gameObject.SetActive(isEnabled);
        }

        foreach (Coin coin in _topCoinsPool)
        {
            var isEnabled = Random.Range(0, 2) == 1 ? true : false;
            coin.gameObject.SetActive(isEnabled);
            coin.transform.position = new Vector2(coin.transform.position.x, coin.transform.position.y);
        }

        foreach (Coin coin in _bottomCoinsPool)
        {
            coin.gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * _moveSpeed);
    }
}