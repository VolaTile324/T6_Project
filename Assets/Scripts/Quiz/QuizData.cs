using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class QuizData
{
    public string question;
    public string[] answers;
    public int correctAnswer;
    public string[] feedbacks;
}
