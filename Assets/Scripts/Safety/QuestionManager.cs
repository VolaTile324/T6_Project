using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class QuestionManager : MonoBehaviour
{
    [SerializeField] GameObject QuestionPanel;
    [SerializeField] TMP_Text[] AnswerTexts;
    [SerializeField] Device Device;

    [SerializeField] QuestionData[] Questions;

    int CurrentQuestionIndex;
    int CorrectAnswers;

    public UnityEvent OnClosePanel;
    private void Start() {
        QuestionPanel.SetActive(false);
    }

    public void StartQuestion() {
        QuestionPanel.SetActive(true);
        CurrentQuestionIndex = Random.Range(0, Questions.Length);
        SetQuestion();
    }

    public void SetQuestion() {
        for (int i = 0; i < AnswerTexts.Length; i++)
        {
            AnswerTexts[i].text = Questions[CurrentQuestionIndex].Answers[i];
        }
        CorrectAnswers = Questions[CurrentQuestionIndex].CorrectAnswer;
    }

    public void CheckAnswer(int answerIndex) {
        if (answerIndex == CorrectAnswers)
        {
            Debug.Log("Correct");
            Device.ChangeHP(10);            
        }
        else
        {
            Debug.Log("Wrong");
            Device.ChangeHP(-10);
        }
        QuestionPanel.SetActive(false);
        OnClosePanel.Invoke();
        
        // CurrentQuestionIndex++;
        // if (CurrentQuestionIndex >= Questions.Length)
        // {
        //     QuestionPanel.SetActive(false);
        // }
        // else
        // {
        //     SetQuestion();
        // }
    }

}
