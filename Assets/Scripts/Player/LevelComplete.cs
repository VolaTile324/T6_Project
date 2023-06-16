using Hex.TopDownGame;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelComplete : MonoBehaviour
{
    [SerializeField] private ScreenFade fadeEffect;
    [SerializeField] private SceneController sceneController;
    [SerializeField] private TopDownCharacterController player;
    [SerializeField] private Image finishedPanel;
    [SerializeField] private TMP_Text summaryBox;
    [SerializeField, TextArea] private string summaryInfo;

    public void TriggerFinished()
    {
        StopAllCoroutines();
        if (player != null)
        {
            player.Freeze();
        }
        sceneController.ToggleHUD(false);
        fadeEffect.gameObject.SetActive(true);
        fadeEffect.StartFadeIn();
        StartCoroutine(EnableFinishedPanelAfterFade());
    }

    IEnumerator EnableFinishedPanelAfterFade()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        fadeEffect.StartFadeOut();
        summaryBox.text = summaryInfo;
        finishedPanel.gameObject.SetActive(true);
        StopAllCoroutines();
    }
}
