using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;


namespace Muco {

    public static class CoroutineUtils
    {
        public static IEnumerator TriggerMethodDelayed(Action method, float delay)
        {
            yield return new WaitForSeconds(delay);
            method?.Invoke();
        }

        public static IEnumerator TriggerMethodDelayed<T>(Action<T> method, T arg, float delay)
        {
            yield return new WaitForSeconds(delay);
            method?.Invoke(arg);
        }

        public static IEnumerator TriggerUnityEventDelayed(UnityEvent unityEvent, float delay)
        {
            yield return new WaitForSeconds(delay);
            unityEvent?.Invoke();
        }

        public static IEnumerator TriggerUnityEventDelayed<T>(UnityEvent<T> unityEvent, T arg, float delay)
        {
            yield return new WaitForSeconds(delay);
            unityEvent?.Invoke(arg);
        }
    }
}