using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuizDataWithImage 
{
    public string question;
    public Sprite questionImage;
    public string[] answers;
    public Sprite[] answerImages;
    public int correctAnswer;
    public string[] feedbacks;
}

