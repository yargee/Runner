using UnityEngine;

public class Coin : MonoBehaviour, IPlatformPlaceble
{
    public void TryEnable()
    {
        gameObject.SetActive(Randomizer.RandomChance(70));
    }
}
