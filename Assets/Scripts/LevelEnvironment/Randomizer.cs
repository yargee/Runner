﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Randomizer
{
    public static bool RandomChance(int chance)
    {
        bool result = Random.Range(0, 100) < chance ? true : false;
        return result;
    }
}
