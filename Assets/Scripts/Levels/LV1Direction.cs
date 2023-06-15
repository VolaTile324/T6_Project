using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV1Direction : MonoBehaviour
{
    [SerializeField] DirectionVisual directionVisual;
    [SerializeField] LevelStateSave levelStateSave;
    
    public void CallSavedDirection()
    {
        if (levelStateSave.ObjectList.Contains("Level1Begins"))
        {
            directionVisual.Directions[0].gameObject.SetActive(true);
            
            if (levelStateSave.ObjectList.Contains("BrotherFinsihed"))
            {
                directionVisual.DisableAllDirs();
                directionVisual.Directions[1].gameObject.SetActive(true);
            }

            if (levelStateSave.ObjectList.Contains("FriendFinished"))
            {
                directionVisual.DisableAllDirs();
                directionVisual.Directions[2].gameObject.SetActive(true);
            }
        }
    }
}
