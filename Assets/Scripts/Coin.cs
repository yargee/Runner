using UnityEngine;

public class Coin : MonoBehaviour, IPlatformSettable
{
    private void OnEnable()
    {        
        TrySetActive();
    }

    public void TrySetActive()
    {
        var isEnabled = Random.Range(0, 2) == 1 ? true : false;
        gameObject.SetActive(isEnabled);
    }
}
