using UnityEngine;
using UnityEngine.Events;

public class TriggerZone : MonoBehaviour
{    
    public UnityEvent NeedNewPlatform;    
    public UnityEvent DeactivatePlatform;    
    

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.TryGetComponent(out Platform platform))
        {            
            NeedNewPlatform?.Invoke();      
        }        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Platform platform))
        {            
            DeactivatePlatform?.Invoke();
        }
    }
}
