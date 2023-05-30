using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Item : MonoBehaviour
{
    [SerializeField] private UnityEvent onAcquired;
    [SerializeField] private UnityEvent onReleased;

    public void OnAcquiredEvent()
    {
        onAcquired.Invoke();
    }

    public void OnReleasedEvent()
    {
        onReleased.Invoke();
    }
}
