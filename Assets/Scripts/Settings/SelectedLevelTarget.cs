using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectedLevelTarget : MonoBehaviour
{
    [SerializeField] private AsyncLoader levelLoader;
    [SerializeField] private SelectedLevel selectedLevelTemplate;
    [SerializeField] private int targetLevel;
    [SerializeField] private Image targetImage;
    [SerializeField] private TMP_Text targetLevelNum;
    [SerializeField] private TMP_Text targetLevelName;
    [SerializeField, TextArea] private string levelDesc;

    public void SetLevel()
    {
        selectedLevelTemplate.LevelImage.sprite = targetImage.sprite;
        selectedLevelTemplate.LevelNum.text = targetLevelNum.text;
        selectedLevelTemplate.LevelName.text = targetLevelName.text;
        selectedLevelTemplate.LevelDescription.text = levelDesc;
        
        selectedLevelTemplate.LoadLevelButton.onClick.RemoveAllListeners();
        selectedLevelTemplate.LoadLevelButton.onClick.AddListener(SceneNumSet);
        if (PlayerPrefs.GetInt(targetLevel + "Continue", 0) == 1)
        {
            selectedLevelTemplate.RestartButton.gameObject.SetActive(true);
            selectedLevelTemplate.RestartAcceptButton.onClick.RemoveAllListeners();
            selectedLevelTemplate.RestartAcceptButton.onClick.AddListener(ResetLevel);
            selectedLevelTemplate.LoadLevelButton.GetComponentInChildren<TMP_Text>().text = "CONTINUE";
        }
    }

    public void SceneNumSet()
    {
        levelLoader.LoadLevel("Level " + targetLevel);
    }

    public void ResetLevel()
    {
        PlayerPrefs.SetInt(targetLevel + "Continue", 0);
        SceneNumSet();
    }
}
