using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] GameObject quizPromptPanel;
    [SerializeField] GameObject quizStartPanel;
    [SerializeField] GameObject quizFinishPanel;
    [SerializeField] GameObject feedbackPanel;
    [SerializeField] TMP_Text feedbackText;
    [SerializeField] TMP_Text questionText;
    [SerializeField] TMP_Text[] answerTexts;
    [SerializeField] TMP_Text quizFinishText;

    [Header("Dialog Data")]
    public QuizData[] quizDatas;

    private int currentQuizIndex;
    private int correctAnswer;
    private int score;

    private void OnEnable()
    {
        quizPromptPanel.SetActive(true);
        quizStartPanel.SetActive(false);
        quizFinishPanel.SetActive(false);
    }

    public void StartQuiz()
    {
        currentQuizIndex = 0;
        score = 0;
        SetQuiz();
        quizPromptPanel.SetActive(false);
        quizStartPanel.SetActive(true);
        quizFinishPanel.SetActive(false);
    }

    private void SetQuiz()
    {
        questionText.text = quizDatas[currentQuizIndex].question;
        for (int i = 0; i < answerTexts.Length; i++)
        {
            answerTexts[i].text = quizDatas[currentQuizIndex].answers[i];
        }
        correctAnswer = quizDatas[currentQuizIndex].correctAnswer;
    }

    //cek jawaban, setiap pilihan jawaban memiliki feedback masing" jd pada string feedbacks itu ada 4 feedback
    public void CheckAnswer(int answerIndex)
    {
        if (answerIndex == correctAnswer)
        {
            Debug.Log("Correct");
            score++;
            feedbackText.text = quizDatas[currentQuizIndex].feedbacks[answerIndex];
        }
        else
        {
            Debug.Log("Wrong");
            feedbackText.text = quizDatas[currentQuizIndex].feedbacks[answerIndex];
        }
        feedbackPanel.SetActive(true);
    }

    //lanjut ke soal berikutnya
    public void NextQuestion()
    {
        currentQuizIndex++;
        feedbackPanel.SetActive(false);
        if (currentQuizIndex < quizDatas.Length)
        {
            SetQuiz();
        }
        else
        {
            Debug.Log("Quiz Finished");
            quizPromptPanel.SetActive(false);
            quizStartPanel.SetActive(false);
            quizFinishPanel.SetActive(true);
            quizFinishText.text = "You got " + score + " out of " + quizDatas.Length + " correct!";
        }
    }


    

    

    // public void CheckAnswer(int answerIndex)
    // {
    //     if (answerIndex == correctAnswer)
    //     {
    //         Debug.Log("Correct");
    //         score++;
    //     }
    //     else
    //     {
    //         Debug.Log("Wrong");
    //     }
    //     currentQuizIndex++;
    //     if (currentQuizIndex < quizDatas.Length)
    //     {
    //         SetQuiz();
    //     }
    //     else
    //     {
    //         Debug.Log("Quiz Finished");
    //         quizPromptPanel.SetActive(false);
    //         quizStartPanel.SetActive(false);
    //         quizFinishPanel.SetActive(true);
    //         quizFinishText.text = "You got " + score + " out of " + quizDatas.Length + " correct!";
    //     }
    // }
    
}
