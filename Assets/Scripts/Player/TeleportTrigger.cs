using Hex.TopDownGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleportTrigger : MonoBehaviour
{
    [SerializeField] private TopDownCharacterController playerCharacter;
    [SerializeField] private TeleportDestination teleportDestination;
    [SerializeField] private float teleportTime = 1;
    [SerializeField] private bool switchLayer = false;
    [SerializeField] private string gotoLayer;
    [SerializeField] private ScreenFade fadeEffect;

    private bool isTeleporting = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StopCoroutine(TeleportToDestination());
        isTeleporting = true;
        playerCharacter.Freeze();
        fadeEffect.gameObject.SetActive(true);
        fadeEffect.StartFadeIn();
        StartCoroutine(TeleportToDestination());
    }

    IEnumerator TeleportToDestination()
    {
        yield return new WaitForSeconds(teleportTime);
        playerCharacter.transform.position = teleportDestination.transform.position;
        isTeleporting = false;
        if (switchLayer)
        {
            playerCharacter.gameObject.layer = LayerMask.NameToLayer(gotoLayer);
        }
        StopCoroutine(TeleportRegainControl());
        StartCoroutine(TeleportRegainControl());
    }

    IEnumerator TeleportRegainControl()
    {
        yield return new WaitForSeconds(1f);
        fadeEffect.StartFadeOut();
        playerCharacter.Unfreeze();
    }
}
