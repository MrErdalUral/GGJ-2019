using System;
using System.Collections;
using UnityEngine;

public static class CommonCoroutines
{
    public static IEnumerator DelayedAction(float delay, Action action)
    {
        yield return new WaitForSeconds(delay);
        action();
    }
}
