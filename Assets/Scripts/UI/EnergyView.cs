using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyView : MonoBehaviour
{
    [SerializeField] private Slider _energyView;
    [SerializeField] private Energy _energy;

    private void OnEnable()
    {
        _energy.EnergyChanged += OnEnergyChanged;
    }

    private void OnDisable()
    {
        _energy.EnergyChanged += OnEnergyChanged;
    }

    public void OnEnergyChanged(float value)
    {
        _energyView.value = value;
    }
}
