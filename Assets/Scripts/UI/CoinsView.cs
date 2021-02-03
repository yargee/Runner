using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsView : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinsView;
    [SerializeField] private Yoba _yoba;

    private void OnEnable()
    {
        _yoba.CoinCollected += OnCoinCollected;
    }

    private void OnDisable()
    {
        _yoba.CoinCollected -= OnCoinCollected;
    }

    private void OnCoinCollected(int value, Coin coin)
    {
        _coinsView.text = value.ToString();
        coin.gameObject.SetActive(false);
    }
}
