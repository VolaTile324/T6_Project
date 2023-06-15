using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SafetyManager : MonoBehaviour
{
    [SerializeField] Slider[] HPBar;
    // [SerializeField] Device[] Devices;
    [SerializeField] GameObject[] Locks;
    [SerializeField] TMP_Text lockText;
    [SerializeField] GameObject[] interactableObjects;

    [SerializeField] GameObject resultPanel;
    [SerializeField] TMP_Text resultText;

    [SerializeField] GameObject quizPromptPanel;

    private void Start() {
        resultPanel.SetActive(false);
        // quizPromptPanel.SetActive(value: true);
    }

    private void Update() {
        // check if HP bar from each device is 0, if yes, lock the device
        for (int i = 0; i < HPBar.Length; i++)
        {
            if (HPBar[i].value == 1)
            {
                HPBar[i].gameObject.SetActive(false);
                Locks[i].SetActive(true);
                lockText.text = CountLockedDevices() + " / " + Locks.Length;
                interactableObjects[i].SetActive(false);
            }
        }     

        // check if all devices are locked, if yes, show result panel
        bool allLocked = true;
        for (int i = 0; i < Locks.Length; i++)
        {
            if (Locks[i].activeSelf == false)
            {
                allLocked = false;
            }
        }

        if (allLocked)
        {
            resultPanel.SetActive(true);
            resultText.text = "Kamu berhasil !";
        }

        // check if one of the HP bar value is 0, then show result panel "kamu gagal melindungi perangkatmu"
        bool oneHPBarZero = false;
        for (int i = 0; i < HPBar.Length; i++)
        {
            if (HPBar[i].value == 0)
            {
                oneHPBarZero = true;
            }
        }

        if (oneHPBarZero)
        {
            resultPanel.SetActive(true);
            resultText.text = "Kamu gagal melindungi perangkatmu";
        }
        
    }

    // method to count the number of locked devices
    public int CountLockedDevices() {
        int count = 0;
        for (int i = 0; i < Locks.Length; i++)
        {
            if (Locks[i].activeSelf == true)
            {
                count++;
            }
        }
        return count;
    }

    public void StartQuiz()
    {
        quizPromptPanel.SetActive(false);
    }

    public void RestartQuiz()
    {
        quizPromptPanel.SetActive(true);
    }

}
