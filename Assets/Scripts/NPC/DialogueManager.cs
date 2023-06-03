using Hex.TopDownGame;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TopDownCharacterController player;
    [Header("Textbox")] 
    [SerializeField] private GameObject _dialogBox;
    [SerializeField] private Button _continueButton;
    [SerializeField] private TMP_Text _dialogText;
    [SerializeField] private TMP_Text _dialogNameText;

    public static DialogueManager Instance;
    
    public DialogData DialogData { get; set; }

    private int dialogIndex;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowDialog()
    {
        _dialogBox.SetActive(true);
        _dialogText.text = DialogData.texts[0].text;
        _dialogNameText.text = DialogData.texts[0].isPlayer ? player.plData.characterName : DialogData.characterName;
        dialogIndex = 0;
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


}
