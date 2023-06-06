using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFade : MonoBehaviour
{
    [SerializeField] private CanvasGroup fadeImage;
    [SerializeField] private float fadeInSpeed = 2.0f;
    [SerializeField] private float fadeOutSpeed = 6.0f;
    private bool fadeIn = false;
    private bool fadeOut = false;

    public void StartFadeIn()
    {
        fadeIn = true;
    }

    public void StartFadeOut()
    {
        fadeOut = true;
    }

    private void Update()
    {
        if (fadeIn)
        {
            fadeOut = false;
            if (fadeImage.alpha < 1)
            {
                fadeImage.alpha += (fadeInSpeed * Time.deltaTime);
                if (fadeImage.alpha >= 1)
                {
                    fadeIn = false;
                }
            }
        }

        if (fadeOut)
        {
            fadeIn = false;
            if (fadeImage.alpha > 0)
            {
                fadeImage.alpha -= (fadeOutSpeed * Time.deltaTime);
                if (fadeImage.alpha <= 0)
                {
                    fadeOut = false;
                    this.gameObject.SetActive(false);
                }
            }
        }
    }
}
