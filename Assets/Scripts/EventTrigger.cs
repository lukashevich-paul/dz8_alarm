using System;
using UnityEngine;

public class EventTrigger : MonoBehaviour
{
    public event Action Enter;
    public event Action Exit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Mover>(out _))
            Enter?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Mover>(out _))
            Exit?.Invoke();
    }
}
