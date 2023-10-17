
using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour
{
    public UnityEvent SteppedOn;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player stepped on the pressure plate.");
            SteppedOn.Invoke();
        }
    }
}
