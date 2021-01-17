using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Platform : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] SpriteRenderer _color;
    [SerializeField] List<Chair> _chairs;
    [SerializeField] private List<Coin> _topCoinsPool;
    [SerializeField] private List<Coin> _bottomCoinsPool;


    private void OnEnable()
    {
        _color.color = new Color32((byte)Random.Range(0,255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);

        foreach(var chair in _chairs)
        {
            var isEnabled = Random.Range(0, 2) == 1 ? true : false;
            chair.gameObject.SetActive(isEnabled);
        }

        foreach (var coin in _topCoinsPool)
        {
            var isEnabled = Random.Range(0, 2) == 1 ? true : false;
            coin.gameObject.SetActive(isEnabled);
            coin.transform.position = new Vector2(coin.transform.position.x, coin.transform.position.y + Random.Range(0, 3));
        }

        foreach (var coin in _bottomCoinsPool)
        {
            coin.gameObject.SetActive(true);            
        }
    }

    private void OnDisable()
    {
        foreach (var coin in _topCoinsPool)
        {
            coin.transform.position = coin.StartPosition.position;
        }
    }

    private void Update()
    {
        transform.Translate(new Vector2(-1, 0) * Time.deltaTime * _moveSpeed);
    }    
}