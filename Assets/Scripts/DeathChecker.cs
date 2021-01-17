using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathChecker : MonoBehaviour
{
    [SerializeField] Yoba _yoba;
    void Update()
    {       
        if (_yoba.transform.position.y < transform.position.y && _yoba != null)
        {            
            _yoba.YobaIsDead?.Invoke();
        }        
    }
}
