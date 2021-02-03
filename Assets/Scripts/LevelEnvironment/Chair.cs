using UnityEngine;

public class Chair : MonoBehaviour, IPlatformPlaceble
{   
    public void TryEnable()
    {
        gameObject.SetActive(Randomizer.RandomChance(60));
    }
}
