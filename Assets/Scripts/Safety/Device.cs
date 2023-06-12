using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Device : MonoBehaviour
{
    [SerializeField] int CurrentHP;
    [SerializeField] int MaxHP;
    [SerializeField] Slider HPBar;

    private void Start() {
        UpdateHPBar();
    }

    public void ChangeHP(int amount) {
        CurrentHP += amount;
        CurrentHP = Mathf.Clamp(CurrentHP, 0, MaxHP);
        UpdateHPBar();
    }

    public void UpdateHPBar()
    {
        HPBar.value = (float)CurrentHP / (float)MaxHP;
    }
}
