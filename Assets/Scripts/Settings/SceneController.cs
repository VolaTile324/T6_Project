using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    [SerializeField] Button pauseButton;
    [SerializeField] VariableJoystick joystick;
    [SerializeField] Image interactButton;

    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(sceneName);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PauseGame()
    {
        if (Time.timeScale > 0)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void ToggleHUD(bool value)
    {
        if (pauseButton != null)
        {
            pauseButton.gameObject.SetActive(value);
        }
        if (joystick != null)
        {
            joystick.gameObject.SetActive(value);
        }
        if (interactButton != null)
        {
            interactButton.gameObject.SetActive(value);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
}
