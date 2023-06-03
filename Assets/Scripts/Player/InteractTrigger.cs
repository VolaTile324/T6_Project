using Hex.TopDownGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InteractTrigger : MonoBehaviour
{
    [SerializeField] private TopDownCharacterController playerCharacter;
    [SerializeField] private GameObject interactPrompt;
    [SerializeField] private Button interactButton;
    [SerializeField] private UnityEvent onInteract;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //safety measure in listener check
            interactButton.onClick.RemoveListener(InteractCall);

            interactPrompt.SetActive(true);
            interactButton.gameObject.SetActive(true);
            interactButton.onClick.AddListener(InteractCall);
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
            interactButton.gameObject.SetActive(false);
            interactButton.onClick.RemoveListener(InteractCall);
        }
    }

    public void InteractCall()
    {
        if (playerCharacter.IsInteracting == false && interactPrompt.activeSelf)
        {
            playerCharacter.Freeze();
            onInteract.Invoke();
        }
    }

    public void DisableInteracting()
    {
        playerCharacter.Unfreeze();
    }
}
