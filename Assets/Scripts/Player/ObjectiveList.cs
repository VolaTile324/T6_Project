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
    [SerializeField] List<string> ongoingList;
    [SerializeField] List<string> completedList;

    private void Start()
    {
        // ongoingList = new List<string>();
        // completedList = new List<string>();
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
            // remove from ongoing list
            ongoingList.Remove(objectiveName);
            // add into completed list
            completedList.Add(objectiveName);
        }
        else
        {
            Debug.Log("Cannot find the specified objective.. it may have been completed/removed/contains typo.");
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

    // clear the actual list
    public void ClearOngoingList()
    {
        ongoingList.Clear();
    }

    public void ClearCompletedList()
    {
        completedList.Clear();
    }
}
