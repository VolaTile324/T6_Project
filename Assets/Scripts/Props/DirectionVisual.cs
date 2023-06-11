using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionVisual : MonoBehaviour
{
    [SerializeField] GameObject[] directions;
    private int arrLength;

    public void CallDirection(GameObject setdirection)
    {
        // deactivate all gameobject directions
        arrLength = directions.Length;
        for (int i = 0; i < arrLength; i++)
        {
            directions[i].gameObject.SetActive(false);
        }
        setdirection.gameObject.SetActive(true);
    }
}
