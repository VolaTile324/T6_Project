using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveList : MonoBehaviour
{
    [SerializeField] private GameObject newGoalAnnouncer;
    [SerializeField] private TMP_Text goalStatus;
    [SerializeField] private TMP_Text goalName;
    [SerializeField] private ObjectiveDisplay goalOngoingTempPrefab;
    [SerializeField] private ObjectiveDisplay goalCompleteTempPrefab;
    [SerializeField] private GameObject goalContentParent;
    [SerializeField] private LevelStateSave levelStateSave;
    [SerializeField] List<string> ongoingList;
    [SerializeField] List<string> completedList;
    private int savedOngoingCount;
    private int savedCompletedCount;

    private void Awake()
    {
        if (PlayerPrefs.GetInt(levelStateSave.LevelNum + "Continue", 0) == 1)
        {
            LoadList();
        }
        else
        {
            // clean the player prefs
            savedOngoingCount = PlayerPrefs.GetInt(levelStateSave.LevelNum + "OngoingCount");
            savedCompletedCount = PlayerPrefs.GetInt(levelStateSave.LevelNum + "CompletedCount");

            for (int i = 0; i < savedOngoingCount; i++)
            {
                PlayerPrefs.DeleteKey(levelStateSave.LevelNum + "Ongoing" + i);
            }

            for (int i = 0; i < savedCompletedCount; i++)
            {
                PlayerPrefs.DeleteKey(levelStateSave.LevelNum + "Completed" + i);
            }

            PlayerPrefs.DeleteKey(levelStateSave.LevelNum + "OngoingCount");
            PlayerPrefs.DeleteKey(levelStateSave.LevelNum + "CompletedCount");

            ongoingList = new List<string>();
            completedList = new List<string>();
        }
    }

    public void AddObjective(string objectiveName)
    {
        StopCoroutine(HideAnnouncer());
        newGoalAnnouncer.SetActive(true);
        goalStatus.text = "New Goal";
        goalName.text = objectiveName;
        StartCoroutine(HideAnnouncer());
        // add into list
        ongoingList.Add(objectiveName);

        // save the list
        SaveList();
    }

    public void CompleteObjective(string objectiveName)
    {
        if (ongoingList.Contains(objectiveName))
        {
            StopCoroutine(HideAnnouncer());
            newGoalAnnouncer.SetActive(true);
            goalStatus.text = "Goal Achieved";
            goalName.text = objectiveName;
            StartCoroutine(HideAnnouncer());

            // remove all player prefs key in ongoing list then save again
            for (int i = 0; i < ongoingList.Count; i++)
            {
                PlayerPrefs.DeleteKey(levelStateSave.LevelNum + "Ongoing" + i);
            }

            // remove from ongoing list
            ongoingList.Remove(objectiveName);
            
            // add into completed list
            completedList.Add(objectiveName);

            // save the list
            SaveList();
        }
        else
        {
            Debug.Log("Cannot find the specified objective.. it may have been completed/removed/contains typo.");
        }
    }

    public void SaveList()
    {
        SaveOngoingList();
        SaveCompletedList();
        PlayerPrefs.Save();
    }

    public void SaveOngoingList()
    {
        for (int i = 0; i < ongoingList.Count; i++)
        {
            PlayerPrefs.SetString(levelStateSave.LevelNum + "Ongoing" + i, ongoingList[i]);
        }

        PlayerPrefs.SetInt(levelStateSave.LevelNum + "OngoingCount", ongoingList.Count);
    }

    public void SaveCompletedList()
    {
        for (int i = 0; i < completedList.Count; i++)
        {
            PlayerPrefs.SetString(levelStateSave.LevelNum + "Completed" + i, completedList[i]);
        }

        PlayerPrefs.SetInt(levelStateSave.LevelNum + "CompletedCount", completedList.Count);
    }

    public void LoadList()
    {
        LoadOngoingList();
        LoadCompletedList();
    }

    public void LoadOngoingList()
    {
        ongoingList.Clear();
        savedOngoingCount = PlayerPrefs.GetInt(levelStateSave.LevelNum + "OngoingCount");

        for (int i = 0; i < savedOngoingCount; i++)
        {
            string ongoingObj = PlayerPrefs.GetString(levelStateSave.LevelNum + "Ongoing" + i);
            ongoingList.Add(ongoingObj);
        }
    }

    public void LoadCompletedList()
    {
        completedList.Clear();
        savedCompletedCount = PlayerPrefs.GetInt(levelStateSave.LevelNum + "CompletedCount");

        for (int i = 0; i < savedCompletedCount; i++)
        {
            string completedObj = PlayerPrefs.GetString(levelStateSave.LevelNum + "Completed" + i);
            completedList.Add(completedObj);
        }
    }

    IEnumerator HideAnnouncer()
    {
        yield return new WaitForSecondsRealtime(3f);
        newGoalAnnouncer.SetActive(false);
    }

    // display the list whenever player open pause menu
    public void DisplayList()
    {
        // display the completed objectives list
        foreach (string objectiveName in completedList)
        {
            ObjectiveDisplay temp = Instantiate(goalOngoingTempPrefab, goalContentParent.transform);
            temp.GoalDesc.text = objectiveName;
            temp.gameObject.SetActive(true);
        }

        // display the ongoing objectives list
        foreach (string objectiveName in ongoingList)
        {
            ObjectiveDisplay temp = Instantiate(goalCompleteTempPrefab, goalContentParent.transform);
            temp.GoalDesc.text = objectiveName;
            temp.gameObject.SetActive(true);
        }
    }

    // clear the display list
    public void ClearDisplayList()
    {
        foreach (Transform child in goalContentParent.transform)
        {
            Destroy(child.gameObject);
        }
    }

    // only clear the actual list, use at your own risk
    public void ClearOngoingList()
    {
        ongoingList.Clear();
    }

    public void ClearCompletedList()
    {
        completedList.Clear();
    }
}
