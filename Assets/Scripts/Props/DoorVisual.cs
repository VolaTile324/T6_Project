using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorVisual : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float distance = 1f;
    [SerializeField] private bool startOpen = false;
    [SerializeField] private AudioSource audioSource;
    [SerializeField, Range(0f, 1f)] private float volume = 1f;
    [SerializeField] private AudioClip openSound;
    [SerializeField] private AudioClip closeSound;
    [SerializeField] private AudioClip lockedSound;

    private Vector2 initialPosition;
    private Vector2 targetPosition;

    private void Start()
    {
        audioSource.volume = volume;
        initialPosition = transform.position;
        targetPosition = initialPosition + Vector2.right * distance;
        if (startOpen)
        {
            transform.position = targetPosition;
        }
    }

    public void Open()
    {
        StopAllCoroutines();
        StartCoroutine(OpenDoor());
    }

    public void Close()
    {
        StopAllCoroutines();
        StartCoroutine(CloseDoor());
    }

    public void Locked()
    {
        audioSource.PlayOneShot(lockedSound);
    }

    private IEnumerator OpenDoor()
    {
        audioSource.PlayOneShot(openSound);
        while (Vector2.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }
        audioSource.Stop();
        audioSource.PlayOneShot(closeSound);
    }

    private IEnumerator CloseDoor()
    {
        audioSource.PlayOneShot(openSound);
        while (Vector2.Distance(transform.position, initialPosition) > 0.01f)
        {
            transform.position = Vector2.MoveTowards(transform.position, initialPosition, speed * Time.deltaTime);
            yield return null;
        }
        audioSource.Stop();
        audioSource.PlayOneShot(closeSound);
    }
}
