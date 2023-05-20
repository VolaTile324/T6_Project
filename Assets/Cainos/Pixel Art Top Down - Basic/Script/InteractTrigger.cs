using Cainos.PixelArtTopDown_Basic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractTrigger : MonoBehaviour
{
    [SerializeField] private GameObject interactPrompt;
    // what to trigger when interacted with
    public UnityEvent onInteract;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactPrompt.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // it follows player positions, translate to make it on top of player
            interactPrompt.transform.position = collision.transform.position + new Vector3(0, 2f, 0);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactPrompt.SetActive(false);
        }
    }

    private void Update()
    {
        if (interactPrompt.gameObject.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                onInteract.Invoke();
            }
        }
    }
}
