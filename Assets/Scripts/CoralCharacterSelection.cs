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

    private Dictionary<GameObject, Vector3> originalPositions = new Dictionary<GameObject, Vector3>();

    [SerializeField] private float stepForwardDistance = 0.25f;
    [SerializeField] private float stepTweenTime = 0.25f;

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

    public void RegisterCurrentPositions()
    {
        originalPositions.Clear();

        foreach (var kid in kidsToInteract)
        {
            originalPositions[kid.gameObject] = kid.transform.position;
        }
    }

    public void SelectKidToSing(AudioSource kidAudioSource)
    {
        var previousKid = currentKidSinging;
        if(currentKidSinging != null) currentKidSinging.Stop();

        currentKidSinging = kidAudioSource;

        if(previousKid != currentKidSinging)
        {
            if(previousKid != null)
            {
                LeanTween.cancel(singTween.id);
                previousKid.gameObject.GetComponent<Animator>().SetBool("isSinging", false);
                previousKid.gameObject.GetComponent<Outline>().isOutline = false;

                if(originalPositions.ContainsKey(previousKid.gameObject))
                {
                    LeanTween.move(previousKid.gameObject,
                        originalPositions[previousKid.gameObject],
                        stepTweenTime);
                }
            }

            currentKidSinging.Play();
            currentKidSinging.gameObject.GetComponent<Animator>().SetBool("isSinging", true);
            currentKidSinging.gameObject.GetComponent<Outline>().isOutline = true;

            if(originalPositions.ContainsKey(currentKidSinging.gameObject))
            {
                Vector3 forwardStep =
                    originalPositions[currentKidSinging.gameObject] +
                    currentKidSinging.transform.forward * stepForwardDistance;

                LeanTween.move(currentKidSinging.gameObject, forwardStep, stepTweenTime);
            }

            singTween = LeanTween.delayedCall(currentKidSinging.clip.length, DisableKidFeedbackOnEndOfClip);
        }
        else
        {
            LeanTween.cancel(singTween.id);
            previousKid.gameObject.GetComponent<Outline>().isOutline = false;
            previousKid.gameObject.GetComponent<Animator>().SetBool("isSinging", false);

            if(originalPositions.ContainsKey(previousKid.gameObject))
            {
                LeanTween.move(previousKid.gameObject,
                    originalPositions[previousKid.gameObject],
                    stepTweenTime);
            }

            currentKidSinging = null;
        }
    }

    private void DisableKidFeedbackOnEndOfClip()
    {
        currentKidSinging.gameObject.GetComponent<Animator>().SetBool("isSinging", false);
        currentKidSinging.gameObject.GetComponent<Outline>().isOutline = false;

        if(originalPositions.ContainsKey(currentKidSinging.gameObject))
        {
            LeanTween.move(currentKidSinging.gameObject,
                originalPositions[currentKidSinging.gameObject],
                stepTweenTime);
        }

        currentKidSinging = null;
        singTween = null;
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

        RegisterCurrentPositions();
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
            kid.gameObject.GetComponent<AudioSource>().Stop();

            if(originalPositions.ContainsKey(kid.gameObject))
            {
                LeanTween.move(kid.gameObject,
                    originalPositions[kid.gameObject],
                    stepTweenTime);
            }

            if(singTween != null)
            {
                LeanTween.cancel(singTween.id);
            }
        }
    }
}