using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelStateLoad : MonoBehaviour
{
    [SerializeField] private LevelStateSave saveManager;
    [SerializeField] private UnityEvent onLevelLoaded;
    [SerializeField] private string keyName;

    private void Start()
    {
        LoadObjectState();
    }

    public void LoadObjectState()
    {
        if (saveManager.ObjectList.Contains(keyName))
        {
            onLevelLoaded.Invoke();
        }
    }
}
