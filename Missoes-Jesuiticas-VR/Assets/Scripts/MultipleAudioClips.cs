using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleAudioClips : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] audioClips;
    public float timeBetweenClips = 1;
    public float timeBeforeStart = 3;
    private int index;
    private float timer = 0f;

    private void Start()
    {
        timer = timeBeforeStart;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            if(index >= audioClips.Length) Destroy(this);
            audioSource.clip = audioClips[index];
            audioSource.Play();
            timer = audioClips[index].length + timeBetweenClips;
            index++;
        }
    }
}
