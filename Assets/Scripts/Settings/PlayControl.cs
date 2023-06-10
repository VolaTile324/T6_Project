using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayControl : MonoBehaviour
{
    [SerializeField] private GameObject characterPanel;
    [SerializeField] private TMP_InputField characterName;
    [SerializeField] private Button saveNameButton;
    [SerializeField] private Button cancelButton;
    
    public void FirstTimeCheck()
    {
        if (PlayerPrefs.HasKey("FirstTime"))
        {
            characterPanel.SetActive(false);
            cancelButton.gameObject.SetActive(true);
            saveNameButton.onClick.RemoveListener(FirstTimeFinished);
        }
        else
        {
            characterPanel.SetActive(true);
            cancelButton.gameObject.SetActive(false);
            saveNameButton.onClick.AddListener(FirstTimeFinished);
        }
    }

    public void FirstTimeFinished()
    {
        PlayerPrefs.SetInt("FirstTime", 1);
        PlayerPrefs.Save();
    }

    public void NameLoad()
    {
        if (PlayerPrefs.HasKey("CharName"))
        {
            characterName.text = PlayerPrefs.GetString("CharName", "Doe");
        }
        else
        {
            characterName.text = "Doe";
        }
    }

    public void NameSave()
    {
        PlayerPrefs.SetString("CharName", characterName.text);
    }

    private void Update()
    {
        if (characterName.text == string.Empty)
        {
            saveNameButton.interactable = false;
        }
        else
        {
            saveNameButton.interactable = true;
        }
    }
}
