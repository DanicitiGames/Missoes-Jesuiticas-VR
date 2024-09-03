using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Narrative : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] audioClips;
    public float timeBetweenClips = 1;
    public float timeBeforeStart = 3;
    private int index = -1;
    private int stage = 0;
    private float timer = 0f;

    public GameObject stage1Object;
    public AudioDetector audioColorMaterial;
    public HeadNodVerifier headNodVerifier;

    public UnityEvent[] CallOnEndTalk;

    private void Start()
    {
        timer = timeBeforeStart;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (stage == 0 && timer <= 0)
        {
            if(index != 1) NextClip();
            else 
            {
                audioColorMaterial.isAwaiting = true;
                stage1Object.SetActive(true);
                stage = 1;
            }
        }
        if (stage == 1 && headNodVerifier.isNodding)
        {
            audioColorMaterial.isAwaiting = false;
            stage1Object.SetActive(false);
            stage = 2;
            NextClip();
        }
        if (stage == 2 && timer <= 0)
        {
            if(index <= audioClips.Length - 1)
            {
                NextClip();
            }
            else
            {
                foreach(var function in CallOnEndTalk)
                {
                    function?.Invoke();
                }
            }
        }
    }

    private void NextClip()
    {
        index++;
        audioSource.clip = audioClips[index];
        audioSource.Play();
        timer = audioClips[index].length;
        if(index != 1) timer += timeBetweenClips;
    }
}
