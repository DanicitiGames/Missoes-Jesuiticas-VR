using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.XR.Interaction.Toolkit;

public class CoralCharacterSelection : MonoBehaviour
{
    [SerializeField] private AudioSource currentKidSinging;
    [SerializeField] private XRSimpleInteractable[] kidsToInteract;
    [SerializeField] private Outline[] kidsOutline;

    private LTDescr singTween = null;

    private void Start()
    {
        foreach (var kid in kidsToInteract)
        {
            kid.enabled = false;
        }

        foreach (var outline in kidsOutline)
        {
            outline.enabled = false;
        }
    }

    public void SelectKidToSing(AudioSource kidAudioSource)
    {
        var previousKid = currentKidSinging;
        if(currentKidSinging != null) currentKidSinging.Stop();

         currentKidSinging = kidAudioSource;

        if(previousKid != currentKidSinging)
        {
            currentKidSinging.Play();
            currentKidSinging.gameObject.GetComponent<Animator>().SetBool("isSinging", true);
            currentKidSinging.gameObject.GetComponent<Outline>().isOutline = true;
            if(previousKid != null)
            {
                LeanTween.cancel(singTween.id);
                previousKid.gameObject.GetComponent<Animator>().SetBool("isSinging", false);
                previousKid.gameObject.GetComponent<Outline>().isOutline = false;
            }
           singTween = LeanTween.delayedCall(currentKidSinging.clip.length, DisableKidFeedbackOnEndOfClip);
        }
        else
        {
            LeanTween.cancel(singTween.id);
            previousKid.gameObject.GetComponent<Outline>().isOutline = false;
            previousKid.gameObject.GetComponent<Animator>().SetBool("isSinging", false);
            currentKidSinging = null;
        }
    }

    private void DisableKidFeedbackOnEndOfClip()
    {
        currentKidSinging.gameObject.GetComponent<Animator>().SetBool("isSinging", false);
        currentKidSinging.gameObject.GetComponent<Outline>().isOutline = false;
        currentKidSinging = null;
    }

    public void EnableInteractionWithCoral()
    {
        foreach(var kid in kidsToInteract)
        {
            kid.enabled = true;
        }

        foreach (var outline in kidsOutline)
        {
            outline.enabled = true;
        }
    }

    public void DisableInteractionWithCoral()
    {
        foreach (var kid in kidsToInteract)
        {
            kid.enabled = false;
        }

        foreach (var outline in kidsOutline)
        {
            outline.enabled = false;
        }
    }

    public void StartAllKidsSing()
    {
        foreach (var kid in kidsToInteract)
        {
            kid.gameObject.GetComponent<Animator>().SetBool("isSinging", true);
            kid.gameObject.GetComponent<Outline>().isOutline = true;
        }
    }

    public void StopAllKidsSing()
    {
        foreach (var kid in kidsToInteract)
        {
            kid.gameObject.GetComponent<Animator>().SetBool("isSinging", false);
            kid.gameObject.GetComponent<Outline>().isOutline = false;
        }
    }
}
