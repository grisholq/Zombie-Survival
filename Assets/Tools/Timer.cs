using System;
using UnityEngine;
using System.Collections;

public class Timer
{
    public float Duraction { get; private set; }
    public event Action Finished;

    private Timer(float duraction)
    {
        Duraction = duraction;
        GlobalMono.Instance.StartCoroutine(DoWithDelay());
    }

    public static Timer Begin(float duration)
    {
        return new Timer(duration);
    }

    private IEnumerator DoWithDelay()
    {
        yield return new WaitForSeconds(Duraction);
        Finished?.Invoke();
    }
}