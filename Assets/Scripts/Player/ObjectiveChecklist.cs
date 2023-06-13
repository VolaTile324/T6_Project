using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectiveChecklist : MonoBehaviour
{
    [SerializeField] ObjectiveList objectiveList;
    [SerializeField] UnityEvent checkListTrigger;
    [SerializeField] List<string> checkListNames;
    private int checkListCondition;

    // Start is called before the first frame update
    void Start()
    {
        ObjCheck();
    }

    public void ObjCheck()
    {
        for (int i = 0; i < checkListNames.Count; i++)
        {
            if (objectiveList.CompletedList.Contains(checkListNames[i]))
            {
                checkListCondition++;
            }
        }

        if (checkListCondition == checkListNames.Count)
        {
            checkListTrigger.Invoke();
        }
    }
}
