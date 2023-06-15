using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionVisual : MonoBehaviour
{
    [SerializeField] GameObject[] directions;
    private int arrLength;

    public GameObject[] Directions { get => directions; set => directions = value; }

    public void CallDirection(GameObject setdirection)
    {
        // deactivate all gameobject directions
        DisableAllDirs();
        setdirection.gameObject.SetActive(true);
    }

    public void DisableAllDirs()
    {
        arrLength = directions.Length;
        for (int i = 0; i < arrLength; i++)
        {
            directions[i].gameObject.SetActive(false);
        }
    }
}
