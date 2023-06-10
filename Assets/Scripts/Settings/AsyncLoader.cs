using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AsyncLoader : MonoBehaviour
{
    [SerializeField] private Canvas loadingScreen;
    [SerializeField] private Canvas menuScreen;
    [SerializeField] private Slider loadingBar;

    public void LoadLevel(string levelToLoad)
    {
        menuScreen.gameObject.SetActive(false);
        loadingScreen.gameObject.SetActive(true);

        StartCoroutine(LoadLevelAsync(levelToLoad));
    }

    IEnumerator LoadLevelAsync(string levelToLoad)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelToLoad);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            loadingBar.value = progress;
            yield return null;
        }
        loadingScreen.gameObject.SetActive(false);
        menuScreen.gameObject.SetActive(true);
        Debug.Log("If you see the main menu again, then the level failed to load..");
    }
}
