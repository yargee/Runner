using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformObject : MonoBehaviour
{
    [SerializeField] private int _spawnChance;

    public int SpawnChance => _spawnChance;

    public void TryEnable(int chance)
    {
        gameObject.SetActive(Randomizer.RandomChance(chance));
    }
}
