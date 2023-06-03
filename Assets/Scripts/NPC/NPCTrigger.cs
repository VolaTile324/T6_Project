using Hex.TopDownGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class NPCTrigger : MonoBehaviour
{
    [SerializeField] private GameObject npcCharacter;
    [SerializeField] private TopDownCharacterController playerCharacter;
    [SerializeField] private Button chatButton;
    [SerializeField] private GameObject chatPrompt;
    [SerializeField] private bool hasDialog;
    [SerializeField] private DialogData data;
    [SerializeField] private UnityEvent onInteract;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //safety measure in listener check
            chatButton.onClick.RemoveListener(InteractCall);

            chatPrompt.SetActive(true);
            chatButton.gameObject.SetActive(true);
            chatButton.onClick.AddListener(InteractCall);
            DialogueManager.Instance.DialogData = data;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // chat prompt stick to npc position
        chatPrompt.transform.position = npcCharacter.transform.position + new Vector3(0, 2f, 0);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            chatPrompt.SetActive(false);
            chatButton.gameObject.SetActive(false);
            chatButton.onClick.RemoveListener(InteractCall);
        }
    }

    public void InteractCall()
    {
        if (playerCharacter.IsInteracting == false && chatPrompt.activeSelf)
        {
            playerCharacter.Freeze();
            onInteract.Invoke();
        }
    }
}
