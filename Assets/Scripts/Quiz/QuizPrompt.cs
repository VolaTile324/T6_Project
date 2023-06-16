using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;

public class QuizPrompt : MonoBehaviour
{
    [SerializeField] TMP_Text promptText;
    [SerializeField] TMP_Text continueText;
    [SerializeField] Button buttonNext;
    [SerializeField] Button buttonStart;

    public PromptData[] promptDatas;

    private int currentPromptIndex;

    public UnityEvent onPromptEnd;

    private void OnEnable() {
        currentPromptIndex = 0;
        StartPrompt();
    }

    public void StartPrompt() {
        promptText.DOFade(0, 0.5f).OnComplete(() => {
                promptText.text = promptDatas[currentPromptIndex].prompt;
                promptText.DOFade(1, 0.5f);
            });
        buttonNext.gameObject.SetActive(true);
        buttonStart.gameObject.SetActive(false);
    }

     

    // public void NextPrompt() {
    //     currentPromptIndex++;
    //     if (currentPromptIndex < promptDatas.Length) {
    //         promptText.text = promptDatas[currentPromptIndex].prompt;
    //     } else {
    //         buttonNext.gameObject.SetActive(false);
    //         buttonStart.gameObject.SetActive(true);
    //     }
    // }

    //next prompt but use DOTween to change the animation when the tmptext prompt changes, in last index, the button next will be disabled and button start will be enabled
    public void NextPrompt() {
        if (currentPromptIndex < promptDatas.Length - 1) {
            currentPromptIndex++;
            promptText.DOFade(0, 0.5f).OnComplete(() => {
                promptText.text = promptDatas[currentPromptIndex].prompt;
                promptText.DOFade(1, 0.5f);
            });
        } else {
            promptText.DOFade(0, 0.5f).OnComplete(() => {
                buttonNext.gameObject.SetActive(false);
                onPromptEnd.Invoke();
            });
            buttonNext.gameObject.SetActive(false);
            onPromptEnd.Invoke(); 
            // buttonStart.gameObject.SetActive(true);
        }
    }

    // public void NextPrompt() {
    //     currentPromptIndex++;
    //     if (currentPromptIndex < promptDatas.Length) {
    //         StartPrompt();
    //     } else {
    //         buttonNext.gameObject.SetActive(false);
    //         buttonStart.gameObject.SetActive(true);
    //     }
    // }
}


