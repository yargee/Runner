using UnityEngine;

public class Chair : MonoBehaviour, IPlatformSettable
{
    private void OnEnable()
    {
        TrySetActive();
    }

    public void TrySetActive()
    {
        var isEnabled = Random.Range(0, 3) == 0 ? false : true;
        gameObject.SetActive(isEnabled);
    }
}
