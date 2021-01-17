using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    [SerializeField] private Transform _startPosition;      

    private void Start()
    {
        _startPosition.position = transform.position;
    }
    
    public Transform StartPosition => _startPosition;
}
