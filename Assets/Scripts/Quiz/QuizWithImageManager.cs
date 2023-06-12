using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class QuizWithImageManager : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] GameObject quizPromptPanel;
    [SerializeField] GameObject quizStartPanel;
    [SerializeField] GameObject quizFinishPanel;
    [SerializeField] GameObject feedbackPanel;
    [SerializeField] TMP_Text feedbackText;
    [SerializeField] TMP_Text questionText;
    [SerializeField] Image questionImage;
    [SerializeField] TMP_Text[] answerTexts;
    [SerializeField] Image[] answerImages;
    [SerializeField] TMP_Text quizFinishText;

    [Header("Dialog Data")]
    public QuizDataWithImage[] quizDatasWithImage;

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
        questionText.text = quizDatasWithImage[currentQuizIndex].question;
        questionImage.sprite = quizDatasWithImage[currentQuizIndex].questionImage;
        
        for (int i = 0; i < answerTexts.Length; i++)
        {
            answerTexts[i].text = quizDatasWithImage[currentQuizIndex].answers[i];
            answerImages[i].sprite = quizDatasWithImage[currentQuizIndex].answerImages[i];
        }
        correctAnswer = quizDatasWithImage[currentQuizIndex].correctAnswer;
    }

    //cek jawaban, setiap pilihan jawaban memiliki feedback masing" jd pada string feedbacks itu ada 4 feedback
    public void CheckAnswer(int answerIndex)
    {
        if (answerIndex == correctAnswer)
        {
            Debug.Log("Correct");
            score++;
            feedbackText.text = quizDatasWithImage[currentQuizIndex].feedbacks[0];
        }
        else
        {
            Debug.Log("Wrong");
            feedbackText.text = quizDatasWithImage[currentQuizIndex].feedbacks[1];
        }
        feedbackPanel.SetActive(true);
    }

    //lanjut ke soal berikutnya
    public void NextQuestion()
    {
        currentQuizIndex++;
        feedbackPanel.SetActive(false);
        if (currentQuizIndex < quizDatasWithImage.Length)
        {
            SetQuiz();
        }
        else
        {
            Debug.Log("Quiz Finished");
            quizPromptPanel.SetActive(false);
            quizStartPanel.SetActive(false);
            quizFinishPanel.SetActive(true);
            quizFinishText.text = "You got " + score + " out of " + quizDatasWithImage.Length + " correct!";
        }
    }

}
