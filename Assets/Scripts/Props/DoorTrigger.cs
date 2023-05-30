using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] DoorVisual door;
    [SerializeField] private bool isLocked = false;
    [SerializeField] private bool useItemRule = false;
    private bool hasItem = false;
    private bool isTriggered = false;

    private void Start()
    {
        // override isLocked to false if useItemRule is set to true,
        // since useItemRule will do it's own lock mechanism
        if (useItemRule)
        {
            isLocked = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isLocked)
        {
            door.Locked();
            Debug.Log("Door is locked");
            return;
        }
        if (useItemRule)
        {
            if (hasItem == false)
            {
                door.Locked();
                Debug.Log("Door is locked, but it can be opened with the right item");
            }
            else if (hasItem == true)
            {
                door.Open();
                Debug.Log("Door should unlock and open");
            }
            return;
        }
        if (isTriggered) return;
        if (collision.CompareTag("Player"))
        {
            door.Open();
            isTriggered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isLocked) return;
        if (useItemRule)
        {
            if (hasItem == false)
            {
                return;
            }
        }
        if (!isTriggered) return;
        if (collision.CompareTag("Player"))
        {
            door.Close();
            isTriggered = false;
        }
    }

    public void ToggleLock()
    {
        if (useItemRule)
        {
            // lets say you got it open without key, like override or something
            if (hasItem == false)
            {
                hasItem = true;
            }
            else
            {
                hasItem = false;
            }
            return;
        }
        if (isLocked)
        {
            isLocked = false;
            Debug.Log("Door is now unlocked");
        }
        else
        {
            isLocked = true;
            Debug.Log("Door is now locked");
        }
    }

    public void HasItem()
    {
        hasItem = true;
    }

    public void LostItem()
    {
        if (hasItem)
        {
            hasItem = false;
        }
    }
}
