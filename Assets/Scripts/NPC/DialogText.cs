using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[Serializable]

public class DialogText : MonoBehaviour
{
    [TextArea]
    public string text;
    public bool isPlayer;
    public bool isQuestion;
    public Button[] answers;
    public bool canSkipIndex;
    public int nextIndex;
    public bool canTriggerEvent;
    public UnityEvent dialogEvent;
}
