using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Countdown : MonoBehaviour
{
    [SerializeField] int duration;
    public UnityEvent OnFinish = new UnityEvent();
    public UnityEvent<int> OnCount = new UnityEvent<int>();
    bool isCounting;

    public void StartCountdown()
    {
        if (isCounting == true)
        {
            StopCoroutine(CountCoroutine());
        }
        StartCoroutine(CountCoroutine());
    }

    private IEnumerator CountCoroutine()
    {
        isCounting = true;
        for (int i = duration; i >= 0; i--)
        {
            OnCount.Invoke(i);
            yield return new WaitForSecondsRealtime(1);
        }
        isCounting = false;
        OnFinish.Invoke();
    }
}
