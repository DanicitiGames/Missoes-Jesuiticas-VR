using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CoralCharacterSelection : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] coralAudioClips;

    public void SelectKidToSing(int index)
    {
        audioSource.clip = coralAudioClips[index];
        audioSource.Play();
    }
}
