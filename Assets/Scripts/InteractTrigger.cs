using Cainos.PixelArtTopDown_Basic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractTrigger : MonoBehaviour
{
    [SerializeField] private TopDownCharacterController character;
    [SerializeField] private GameObject interactPrompt;
    [SerializeField] private UnityEvent onInteract;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactPrompt.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // interact prompt follow player position
        interactPrompt.transform.position = collision.transform.position + new Vector3(0, 2f, 0);
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
        if (character.isInteracting == false && interactPrompt.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            onInteract.Invoke();
        }
    }
}
