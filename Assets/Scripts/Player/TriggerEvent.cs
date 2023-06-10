using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{
    [SerializeField] private bool triggerOnce = true;
    [SerializeField] private bool triggerOnEnter = true;
    [SerializeField] private bool triggerOnExit = false;
    [SerializeField] private bool triggerOnStay = false;
    [SerializeField] private UnityEvent triggerTarget;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && triggerOnEnter)
        {
            Debug.Log("Triggered");
            TriggerTarget();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // will trigger every frame, careful with this one
        if (collision.CompareTag("Player") && triggerOnStay)
        {
            Debug.Log("Triggered");
            TriggerTarget();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && triggerOnExit)
        {
            Debug.Log("Triggered");
            TriggerTarget();
        }
    }

    private void TriggerTarget()
    {
        if (triggerOnce)
        {
            triggerTarget.Invoke();            
            Destroy(this.gameObject);
            Debug.Log("Triggered and Removed");
        }
        else
        {
            triggerTarget.Invoke();
        }
    }
}
