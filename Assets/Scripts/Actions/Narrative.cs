using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Narrative : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    public AudioClip[] audioClips;
    public float timeBetweenClips = 1;
    public float timeBeforeStart = 3;
    private int index = -1;
    private int stage = 0;
    private float timer = 0f;

    [SerializeField] private bool hasConfirmation = false;
    public GameObject stage1Object;
    public AudioDetector audioColorMaterial;
    public HeadNodVerifier headNodVerifier;

    [SerializeField] private AudioClip[] tooltipTriggerAudio;
    [SerializeField] private GameObject[] tooltips;
    private int currentTooltipIndex = -1;

    public UnityEvent[] CallOnEndTalk;

    private void Start()
    {
        timer = timeBeforeStart;
        if (!audioSource) audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (stage == 0 && timer <= 0)
        {
            if (index >= audioClips.Length - 1)
            {
                stage = 2;
                return;
            }
            if (index != 1) NextClip();
            else
            {
                if (hasConfirmation)
                {
                    audioColorMaterial.isAwaiting = true;
                    stage1Object.SetActive(true);
                    stage = 1;
                }
                else
                {
                    stage = 2;
                    NextClip();
                }
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
            if (index < audioClips.Length - 1)
            {
                NextClip();
            }
            else
            {
                CallEndUnityEvents();
            }
        }
    }

    private void CallEndUnityEvents()
    {
        foreach (var function in CallOnEndTalk)
        {
            function?.Invoke();
        }
        this.enabled = false;
    }

    private void HandleTooltip(AudioClip currentClip)
    {
        if (tooltipTriggerAudio == null || tooltips == null) return;
        if (tooltipTriggerAudio.Length == 0 || tooltips.Length == 0) return;

        int newIndex = System.Array.IndexOf(tooltipTriggerAudio, currentClip);

        if (newIndex < 0 || newIndex >= tooltips.Length)
        {
            CloseCurrentTooltip();
            return;
        }

        if (newIndex == currentTooltipIndex)
            return;

        CloseCurrentTooltip();

        if (tooltips[newIndex] != null)
        {
            tooltips[newIndex].SetActive(true);
            currentTooltipIndex = newIndex;
        }
    }

    public void CloseTooltipByButton()
    {
        CloseCurrentTooltip();
    }

    private void CloseCurrentTooltip()
    {
        if (currentTooltipIndex >= 0 &&
            currentTooltipIndex < tooltips.Length &&
            tooltips[currentTooltipIndex] != null)
        {
            tooltips[currentTooltipIndex].SetActive(false);
        }

        currentTooltipIndex = -1;
    }

    private void NextClip()
    {

        index++;
        print("Index: " + index + " audio clip length: " + (audioClips.Length));
        audioSource.clip = audioClips[index];
        audioSource.Play();
        timer = audioClips[index].length;
        if (index != 1) timer += timeBetweenClips;
        HandleTooltip(audioSource.clip);
    }
}
