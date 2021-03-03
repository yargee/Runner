using UnityEngine;
using UnityEngine.Events;

public class DeathChecker : MonoBehaviour
{
    [SerializeField] private Transform _deathPoint;       

    public event UnityAction DeathPointReached;

    private void Update()
    {
        if (transform.position.y < _deathPoint.position.y)
        {            
            DeathPointReached?.Invoke();
        }
    }
}
