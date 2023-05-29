using Cainos.PixelArtTopDown_Basic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ChatTrigger : MonoBehaviour
{
    // todo : NPC class
    // [SerializeField] private NPC npcCharacter;
    [SerializeField] private TopDownCharacterController playerCharacter;
    [SerializeField] private GameObject chatPrompt;
    [SerializeField] private Button chatButton;
    [SerializeField] private UnityEvent onInteract;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            chatPrompt.SetActive(true);
            chatButton.gameObject.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // chat prompt stick to npc position
        // chatPrompt.transform.position = npcCharacter.transform.position + new Vector3(0, 2f, 0);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            chatPrompt.SetActive(false);
            chatButton.gameObject.SetActive(false);
        }
    }

    public void InteractCall()
    {
        if (playerCharacter.isInteracting == false && chatPrompt.activeSelf)
        {
            onInteract.Invoke();
        }
    }
}
