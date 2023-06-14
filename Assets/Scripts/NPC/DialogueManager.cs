using Hex.TopDownGame;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TopDownCharacterController player;
    [Header("Textbox")] 
    [SerializeField] private GameObject _dialogBox;
    [SerializeField] private Button _continueButton;
    [SerializeField] private TMP_Text _dialogText;
    [SerializeField] private TMP_Text _dialogNameText;
    [SerializeField] private Image _playerImage;
    [SerializeField] private Image _NPCImage;
    [SerializeField] private Image _dialogImageBackground;
    [SerializeField] private Image _continueIndicator;

    public static DialogueManager Instance;
    
    public DialogData DialogData { get; set; }

    private int dialogIndex;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowDialog()
    {
        _dialogImageBackground.sprite = DialogData.backgroundImage;
        _dialogBox.SetActive(true);
        _dialogText.text = DialogData.texts[0].text;
        _dialogNameText.text = DialogData.texts[0].isPlayer ? player.plData.characterName : DialogData.characterName;
        _playerImage.sprite = DialogData.texts[0].isPlayer ? player.plData.characterImage : player.plData.characterImage;
        _playerImage.DOFade(DialogData.texts[0].isPlayer ? 1 : 0, duration: 0.5f);
        _NPCImage.sprite = DialogData.texts[0].isPlayer ? DialogData.characterImage : DialogData.characterImage;
        _NPCImage.DOFade(DialogData.texts[0].isPlayer ? 0 : 1, 0.5f);
        dialogIndex = 0;
        _continueIndicator.transform.DOLocalMoveY(_continueIndicator.transform.localPosition.y + 10, 0.5f).SetLoops(-1, LoopType.Yoyo);
        if (DialogData.texts[0].isQuestion)
        {
            QuestionButtons(0);
            _continueButton.gameObject.SetActive(false);
        }
        else
        {
            CanSkipCheck();
        }
    }

    public void ContinueDialog()
    {
        dialogIndex++;
        if (dialogIndex < DialogData.texts.Length)
        {
            _dialogText.text = DialogData.texts[dialogIndex].text;
            _dialogNameText.text = DialogData.texts[dialogIndex].isPlayer ? player.plData.characterName : DialogData.characterName;
            _playerImage.sprite = DialogData.texts[dialogIndex].isPlayer ? player.plData.characterImage : player.plData.characterImage;
            _playerImage.DOFade(DialogData.texts[dialogIndex].isPlayer ? 1 : 0, 0.5f);
            _NPCImage.sprite = DialogData.texts[dialogIndex].isPlayer ? DialogData.characterImage : DialogData.characterImage;
            _NPCImage.DOFade(DialogData.texts[dialogIndex].isPlayer ? 0 : 1, 0.5f);
            
            if (DialogData.texts[dialogIndex].isQuestion)
            {
                QuestionButtons(dialogIndex);
                _continueButton.gameObject.SetActive(false);
            }
            else
            {
                CanSkipCheck();
            }
        }
        else
        {
            _dialogBox.SetActive(false);
            player.Unfreeze();
        }
    }

    public void GoToDialog(int value)
    {
        dialogIndex = value;
        if (dialogIndex < DialogData.texts.Length)
        {
            _dialogText.text = DialogData.texts[dialogIndex].text;
            _dialogNameText.text = DialogData.texts[dialogIndex].isPlayer ? player.plData.characterName : DialogData.characterName;
            if (DialogData.texts[dialogIndex].isQuestion)
            {
                QuestionButtons(dialogIndex);
                _continueButton.gameObject.SetActive(false);
            }
            else
            {
                CanSkipCheck();
            }
        }
        else
        {
            _dialogBox.SetActive(false);
            player.Unfreeze();
        }
    }

    public void SkipToDialog()
    {
        dialogIndex = DialogData.texts[dialogIndex].nextIndex;
        GoToDialog(dialogIndex);
    }

    public void QuestionButtons(int value)
    {
        for (int i = 0; i < DialogData.texts[value].answers.Length; i++)
        {
            DialogData.texts[value].answers[i].gameObject.SetActive(true);
        }
    }

    public void CanSkipCheck()
    {
        _continueButton.onClick.RemoveAllListeners();
        if (DialogData.texts[dialogIndex].canTriggerEvent)
        {
            _continueButton.onClick.AddListener(DialogEventTrigger);
        }

        if (DialogData.texts[dialogIndex].canSkipIndex)
        {
            _continueButton.onClick.AddListener(SkipToDialog);
        }
        else
        {
            _continueButton.onClick.AddListener(ContinueDialog);
        }
        _continueButton.gameObject.SetActive(true);
    }

    public void DialogEventTrigger()
    {
        DialogData.texts[dialogIndex].dialogEvent.Invoke();
    }
}
