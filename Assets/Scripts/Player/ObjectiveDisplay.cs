using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectiveDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text goalDesc;

    public TMP_Text GoalDesc { get => goalDesc; }
}
