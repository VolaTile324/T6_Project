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
            resultText.text = "You have successfully secured all devices!";
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


    
    

}
