using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StopAudioAfterTimer : MonoBehaviour
{
    [SerializeField] private float timeToWait = 1f;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private UnityEvent callOnStopAudio;

    public void StopAudioAfterAmountOfTime()
    {
        LeanTween.delayedCall(timeToWait, () =>
        {
            if(audioSource != null) audioSource.Stop();

            callOnStopAudio?.Invoke();
        });
    }
}
