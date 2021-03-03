using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private int _coins = 0;

    public int Coins => _coins;

    public void CollectCoin()
    {
        _coins++;
    }

    public void LoseCoins()
    {
        _coins = 0;
    }
}
