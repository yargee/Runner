using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Jumper))]
public class Energy : MonoBehaviour
{
    private Jumper _jumper;
    private float _value = 5;
    private float _energyCost = 1.5f;

    public event UnityAction<float> EnergyChanged;

    public float Value => _value;

    private void Awake()
    {
        _jumper = GetComponent<Jumper>();
    }

    private void OnEnable()
    {
        _jumper.YobaJumped += OnYobaJumped;
    }

    private void OnDisable()
    {
        _jumper.YobaJumped -= OnYobaJumped;
    }

    private void Update()
    {
        if (_value <= 10)
        {            
            _value += Time.deltaTime;
            EnergyChanged?.Invoke(_value);
        }
    }

    private void OnYobaJumped()
    {
        _value -= _energyCost;
        EnergyChanged?.Invoke(_value);
    }
}
