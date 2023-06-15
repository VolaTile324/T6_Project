using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
    [Header("Cutscene Elements")]
    [SerializeField] Image background;
    [SerializeField] TMP_Text cutsceneText;
    [SerializeField] GameObject continueIndicator;
    [SerializeField] Image blackFade;

    [Header("Cutscene Settings")]
    [SerializeField] float fadeTime = 1f;

    [Header("Cutscene Data")]
    [SerializeField] CutsceneData[] cutsceneData;

    [Header("Cutscene Events")]
    public UnityEvent onCutsceneEnd;

    
    //nambah event
    int currentCutsceneIndex = 0;

    private void Start()
    {
        BlackFadeOut();
        PlayCutscene();
    }

    //fix scale of the background image
    private void Update()
    {
        background.rectTransform.localScale = new Vector3(1, 1, 1);
    }

    public void PlayCutscene()
    {
        blackFade.DOFade(1, 0);
        BlackFadeOut();
        background.sprite = cutsceneData[currentCutsceneIndex].background;
        cutsceneText.text = cutsceneData[currentCutsceneIndex].text;
        // animating the continue indicator to move top and bottom loop a little bit
        continueIndicator.transform.DOLocalMoveY(continueIndicator.transform.localPosition.y + 10, 0.5f).SetLoops(-1, LoopType.Yoyo);
    }

    public void BlackFadeIn()
    {
        blackFade.gameObject.SetActive(true);
        blackFade.DOFade(1, fadeTime).OnComplete(() => blackFade.gameObject.SetActive(false));
    }

    public void BlackFadeOut()
    {
        blackFade.gameObject.SetActive(true);
        blackFade.DOFade(0, fadeTime).OnComplete(() => blackFade.gameObject.SetActive(false));
    }

    //Next scene
    public void NextCutscene()
    {
        if (currentCutsceneIndex < cutsceneData.Length - 1)
        {
            currentCutsceneIndex++;
            PlayCutscene();
        }
        else
        {
            EndCutscene();
        }
    }


    public void EndCutscene()
    {
        BlackFadeIn();
        background.DOFade(0, fadeTime).OnComplete(() => gameObject.SetActive(false));
        onCutsceneEnd.Invoke();
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}

[System.Serializable]
public class CutsceneData
{
    public string text;
    public Sprite background;
}


