using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectedLevel : MonoBehaviour
{
    [SerializeField] private Image levelImage;
    [SerializeField] private TMP_Text levelNum;
    [SerializeField] private TMP_Text levelName;
    [SerializeField] private TMP_Text levelDescription;
    [SerializeField] private Button loadLevelButton;

    public Image LevelImage { get => levelImage; set => levelImage = value; }
    public TMP_Text LevelNum { get => levelNum; set => levelNum = value; }
    public TMP_Text LevelName { get => levelName; set => levelName = value; }
    public TMP_Text LevelDescription { get => levelDescription; set => levelDescription = value; }
    public Button LoadLevelButton { get => loadLevelButton; set => loadLevelButton = value; }
}
