using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformObject : MonoBehaviour
{
    public void TryEnable(int chance)
    {
        gameObject.SetActive(Randomizer.RandomChance(chance));
    }
}
