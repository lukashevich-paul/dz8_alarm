using System;
using UnityEngine;

public class ThiefDetector : MonoBehaviour
{
    public event Action Entered;
    public event Action Exited;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Mover>(out _))
            Entered?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Mover>(out _))
            Exited?.Invoke();
    }
}
