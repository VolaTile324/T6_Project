using Hex.TopDownGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelStateSave : MonoBehaviour
{
    [SerializeField] private TopDownCharacterController player;
    [SerializeField] private List<string> objectList;
    [SerializeField] private int levelNum;
    private int objectListCount;

    public List<string> ObjectList { get => objectList; set => objectList = value; }
    public int LevelNum { get => levelNum; set => levelNum = value; }

    private void Awake()
    {
        if (PlayerPrefs.GetInt(levelNum + "Continue", 0) == 1)
        {
            LoadCurrentStateList();
            if (player != null)
            {
                player.transform.position = (new Vector2(
                PlayerPrefs.GetFloat("PlayerX", player.transform.position.x),
                PlayerPrefs.GetFloat("PlayerY", player.transform.position.y)
                ));
            }
        }
        else
        {
            // clean the player prefs
            objectListCount = PlayerPrefs.GetInt(levelNum + "SavedObjectCount");

            for (int i = 0; i < objectListCount; i++)
            {
                PlayerPrefs.DeleteKey(levelNum + "SavedObject" + i);
            }

            PlayerPrefs.DeleteKey(levelNum + "SavedObjectCount");
            objectList = new List<string>();
        }
    }

    public void LoadCurrentStateList()
    {
        objectList.Clear();
        objectListCount = PlayerPrefs.GetInt(levelNum + "SavedObjectCount");
        for (int i = 0; i < objectListCount; i++)
        {
            objectList.Add(PlayerPrefs.GetString(levelNum + "SavedObject" + i));
        }
    }
    public void SaveCurrentStateList(string objName)
    {
        if (objectList.Contains(objName))
        {
            Debug.Log("Object state already exists..");
            return;
        }
        
        objectList.Add(objName);
        for (int i = 0; i < objectList.Count; i++)
        {
            PlayerPrefs.SetString(levelNum + "SavedObject" + i, objectList[i]);
        }
        PlayerPrefs.SetInt(levelNum + "SavedObjectCount", objectList.Count);
        PlayerPrefs.SetInt(levelNum + "Continue", 1); // 1 = true, 0 = false

        if (player != null)
        {
            PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
            PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
        }

        PlayerPrefs.Save();
    }
}
